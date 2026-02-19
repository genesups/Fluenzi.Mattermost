using Microsoft.Extensions.Logging;

namespace Fluenzi.Mattermost.WebSocket.Internal;

internal sealed class HeartbeatManager : IDisposable
{
    private readonly TimeSpan _interval;
    private readonly TimeSpan _pongTimeout;
    private readonly ILogger _logger;
    private readonly Func<CancellationToken, Task> _sendPing;
    private readonly Action _onTimeout;
    private CancellationTokenSource? _cts;
    private Task? _heartbeatLoop;
    private DateTime _lastPongReceived;

    public HeartbeatManager(
        WebSocketClientOptions options,
        ILogger logger,
        Func<CancellationToken, Task> sendPing,
        Action onTimeout)
    {
        _interval = options.HeartbeatInterval;
        _pongTimeout = options.PongTimeout;
        _logger = logger;
        _sendPing = sendPing;
        _onTimeout = onTimeout;
    }

    public void Start()
    {
        Stop();
        _lastPongReceived = DateTime.UtcNow;
        _cts = new CancellationTokenSource();
        _heartbeatLoop = RunAsync(_cts.Token);
    }

    public void RecordPong()
    {
        _lastPongReceived = DateTime.UtcNow;
    }

    public void Stop()
    {
        _cts?.Cancel();
        _cts?.Dispose();
        _cts = null;
        _heartbeatLoop = null;
    }

    private async Task RunAsync(CancellationToken ct)
    {
        while (!ct.IsCancellationRequested)
        {
            try
            {
                await Task.Delay(_interval, ct);

                if (DateTime.UtcNow - _lastPongReceived > _interval + _pongTimeout)
                {
                    _logger.LogWarning("WebSocket heartbeat timeout — no pong received for {Timeout}", _interval + _pongTimeout);
                    _onTimeout();
                    return;
                }

                await _sendPing(ct);
            }
            catch (OperationCanceledException) { break; }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Heartbeat error");
            }
        }
    }

    public void Dispose() => Stop();
}
