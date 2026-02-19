using Fluenzi.Mattermost.Interfaces.Auth;
using Fluenzi.Mattermost.Interfaces.Client;
using Fluenzi.Mattermost.Interfaces.Store;
using Fluenzi.Mattermost.Interfaces.WebSocket;

namespace Fluenzi.Mattermost;

public class MattermostSession : IAsyncDisposable
{
    private readonly MattermostOptions _options;

    public IAuthProvider Auth { get; }
    public IMattermostApiClient Api { get; }
    public IMattermostWebSocket WebSocket { get; }
    public IWebSocketEventStream EventStream { get; }
    public IMattermostStore Store { get; }

    public MattermostSession(
        MattermostOptions options,
        IAuthProvider auth,
        IMattermostApiClient api,
        IMattermostWebSocket webSocket,
        IWebSocketEventStream eventStream,
        IMattermostStore store)
    {
        _options = options;
        Auth = auth;
        Api = api;
        WebSocket = webSocket;
        EventStream = eventStream;
        Store = store;
    }

    public async Task ConnectAsync(string token, CancellationToken ct = default)
    {
        var result = await Auth.LoginWithTokenAsync(token, ct);
        if (!result.Success)
            throw new InvalidOperationException($"Authentication failed: {result.Error}");

        var serverUri = new Uri(_options.ServerUrl);
        await WebSocket.ConnectAsync(token, serverUri, ct);
    }

    public async Task ConnectAsync(string username, string password, CancellationToken ct = default)
    {
        var result = await Auth.LoginWithCredentialsAsync(username, password, ct);
        if (!result.Success)
            throw new InvalidOperationException($"Authentication failed: {result.Error}");

        var serverUri = new Uri(_options.ServerUrl);
        await WebSocket.ConnectAsync(result.Token!, serverUri, ct);
    }

    public async Task DisconnectAsync()
    {
        await WebSocket.DisconnectAsync();
        await Auth.LogoutAsync();
        Store.ClearAll();
    }

    public async ValueTask DisposeAsync()
    {
        await WebSocket.DisposeAsync();
        (Store as IDisposable)?.Dispose();
    }
}
