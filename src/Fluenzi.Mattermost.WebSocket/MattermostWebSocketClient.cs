using System.Buffers;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using Fluenzi.Mattermost.Constants;
using Fluenzi.Mattermost.Enums;
using Fluenzi.Mattermost.Events;
using Fluenzi.Mattermost.Interfaces.WebSocket;
using Fluenzi.Mattermost.WebSocket.Internal;
using Microsoft.Extensions.Logging;
using R3;

namespace Fluenzi.Mattermost.WebSocket;

public sealed class MattermostWebSocketClient : IMattermostWebSocket, IWebSocketEventStream
{
    private readonly WebSocketClientOptions _options;
    private readonly ILogger<MattermostWebSocketClient> _logger;
    private readonly EventDeserializer _deserializer;
    private readonly ReconnectionPolicy _reconnectionPolicy;
    private readonly SequenceTracker _sequenceTracker;

    private readonly Subject<WebSocketEventEnvelope> _eventSubject = new();
    private readonly ReactiveProperty<ConnectionState> _connectionState = new(Enums.ConnectionState.Disconnected);

    private ClientWebSocket? _ws;
    private CancellationTokenSource? _cts;
    private Task? _receiveLoop;
    private HeartbeatManager? _heartbeat;
    private string? _token;
    private Uri? _serverUri;
    private int _seq;

    public MattermostWebSocketClient(WebSocketClientOptions options, ILogger<MattermostWebSocketClient> logger)
    {
        _options = options;
        _logger = logger;
        _deserializer = new EventDeserializer(logger);
        _reconnectionPolicy = new ReconnectionPolicy(options);
        _sequenceTracker = new SequenceTracker((expected, actual) =>
            _logger.LogWarning("WebSocket sequence gap: expected {Expected}, got {Actual}", expected + 1, actual));
    }

    public bool IsConnected => _connectionState.Value == Enums.ConnectionState.Connected;
    public ConnectionState CurrentState => _connectionState.Value;

    // IWebSocketEventStream
    public IObservable<WebSocketEventEnvelope> Events => _eventSubject.AsSystemObservable();
    public IObservable<ConnectionState> ConnectionStateChanged => _connectionState.AsSystemObservable();

    public IObservable<T> OfType<T>() where T : WebSocketEvent
    {
        return System.Reactive.Linq.Observable.Create<T>(observer =>
        {
            var disposable = _eventSubject.Subscribe(envelope =>
            {
                var evt = _deserializer.DeserializeEvent(envelope);
                if (evt is T typed)
                    observer.OnNext(typed);
            });
            return System.Reactive.Disposables.Disposable.Create(() => disposable.Dispose());
        });
    }

    public async Task ConnectAsync(string token, Uri serverUri, CancellationToken ct = default)
    {
        _token = token;
        _serverUri = serverUri;
        _reconnectionPolicy.Reset();
        _sequenceTracker.Reset();

        await ConnectInternalAsync(ct);
    }

    public async Task DisconnectAsync(CancellationToken ct = default)
    {
        _connectionState.Value = Enums.ConnectionState.Disconnected;
        _heartbeat?.Stop();

        if (_cts != null)
        {
            await _cts.CancelAsync();
            _cts.Dispose();
            _cts = null;
        }

        if (_ws != null && _ws.State == WebSocketState.Open)
        {
            try
            {
                await _ws.CloseAsync(WebSocketCloseStatus.NormalClosure, "Client disconnect", CancellationToken.None);
            }
            catch { /* Best effort close */ }
        }

        _ws?.Dispose();
        _ws = null;
    }

    public async Task SendAsync(string action, object? data = null, CancellationToken ct = default)
    {
        if (_ws?.State != WebSocketState.Open)
            throw new InvalidOperationException("WebSocket is not connected");

        var seq = Interlocked.Increment(ref _seq);
        var message = new { action, seq, data };
        var json = JsonSerializer.SerializeToUtf8Bytes(message);

        await _ws.SendAsync(json, WebSocketMessageType.Text, true, ct);
    }

    private async Task ConnectInternalAsync(CancellationToken ct)
    {
        _connectionState.Value = Enums.ConnectionState.Connecting;
        _logger.LogInformation("Connecting to Mattermost WebSocket at {Uri}", _serverUri);

        _ws?.Dispose();
        _ws = new ClientWebSocket();
        _ws.Options.SetRequestHeader("Authorization", $"Bearer {_token}");

        var wsUri = BuildWebSocketUri(_serverUri!);

        try
        {
            await _ws.ConnectAsync(wsUri, ct);
            _connectionState.Value = Enums.ConnectionState.Connected;
            _reconnectionPolicy.Reset();
            _logger.LogInformation("WebSocket connected");

            _cts = new CancellationTokenSource();

            _heartbeat?.Dispose();
            _heartbeat = new HeartbeatManager(_options, _logger, SendPingAsync, OnHeartbeatTimeout);
            _heartbeat.Start();

            _receiveLoop = Task.Run(() => ReceiveLoopAsync(_cts.Token), _cts.Token);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "WebSocket connection failed");
            _connectionState.Value = Enums.ConnectionState.Disconnected;
            _ = Task.Run(() => ReconnectAsync());
        }
    }

    private async Task ReceiveLoopAsync(CancellationToken ct)
    {
        var buffer = ArrayPool<byte>.Shared.Rent(_options.ReceiveBufferSize);
        try
        {
            using var messageBuffer = new MemoryStream();
            while (!ct.IsCancellationRequested && _ws?.State == WebSocketState.Open)
            {
                messageBuffer.SetLength(0);
                WebSocketReceiveResult result;

                do
                {
                    result = await _ws.ReceiveAsync(new ArraySegment<byte>(buffer), ct);
                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        _logger.LogInformation("WebSocket server sent close frame");
                        _ = Task.Run(() => ReconnectAsync());
                        return;
                    }
                    messageBuffer.Write(buffer, 0, result.Count);

                    if (messageBuffer.Length > _options.MaxMessageSize)
                    {
                        _logger.LogWarning("WebSocket message exceeds max size ({Size} bytes), skipping", messageBuffer.Length);
                        messageBuffer.SetLength(0);
                        break;
                    }
                } while (!result.EndOfMessage);

                if (messageBuffer.Length == 0) continue;

                ProcessMessage(messageBuffer.ToArray());
            }
        }
        catch (OperationCanceledException) { /* Normal shutdown */ }
        catch (WebSocketException ex)
        {
            _logger.LogWarning(ex, "WebSocket receive error");
            _ = Task.Run(() => ReconnectAsync());
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(buffer);
        }
    }

    private void ProcessMessage(byte[] message)
    {
        var envelope = _deserializer.ParseEnvelope(message);
        if (envelope == null) return;

        _sequenceTracker.Track(envelope.Sequence);

        if (envelope.EventType == WebSocketEventType.Hello)
        {
            _heartbeat?.RecordPong();
        }

        _eventSubject.OnNext(envelope);
    }

    private async Task ReconnectAsync()
    {
        if (_connectionState.Value == Enums.ConnectionState.Disconnected && _token == null)
            return; // Explicit disconnect, don't reconnect

        if (!_reconnectionPolicy.CanRetry)
        {
            _logger.LogError("Max reconnect attempts reached");
            _connectionState.Value = Enums.ConnectionState.Disconnected;
            return;
        }

        _connectionState.Value = Enums.ConnectionState.Reconnecting;
        _heartbeat?.Stop();

        var delay = _reconnectionPolicy.NextDelay();
        _logger.LogInformation("Reconnecting in {Delay}ms (attempt {Attempt})", delay.TotalMilliseconds, _reconnectionPolicy.Attempt);

        await Task.Delay(delay);

        if (_token != null && _serverUri != null)
        {
            await ConnectInternalAsync(CancellationToken.None);
        }
    }

    private async Task SendPingAsync(CancellationToken ct)
    {
        if (_ws?.State == WebSocketState.Open)
        {
            var ping = Encoding.UTF8.GetBytes("{\"action\":\"ping\",\"seq\":" + Interlocked.Increment(ref _seq) + "}");
            await _ws.SendAsync(ping, WebSocketMessageType.Text, true, ct);
        }
    }

    private void OnHeartbeatTimeout()
    {
        _logger.LogWarning("Heartbeat timeout, initiating reconnect");
        _ = Task.Run(() => ReconnectAsync());
    }

    private static Uri BuildWebSocketUri(Uri serverUri)
    {
        var scheme = serverUri.Scheme == "https" ? "wss" : "ws";
        var builder = new UriBuilder(serverUri)
        {
            Scheme = scheme,
            Path = ApiRoutes.WebSocket
        };
        return builder.Uri;
    }

    public async ValueTask DisposeAsync()
    {
        await DisconnectAsync();
        _eventSubject.Dispose();
        _connectionState.Dispose();
        _heartbeat?.Dispose();
    }
}
