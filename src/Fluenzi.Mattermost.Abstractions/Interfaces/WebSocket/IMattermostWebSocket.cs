using Fluenzi.Mattermost.Enums;

namespace Fluenzi.Mattermost.Interfaces.WebSocket;

public interface IMattermostWebSocket : IAsyncDisposable
{
    bool IsConnected { get; }
    ConnectionState CurrentState { get; }
    Task ConnectAsync(string token, Uri serverUri, CancellationToken ct = default);
    Task DisconnectAsync(CancellationToken ct = default);
    Task SendAsync(string action, object? data = null, CancellationToken ct = default);
}
