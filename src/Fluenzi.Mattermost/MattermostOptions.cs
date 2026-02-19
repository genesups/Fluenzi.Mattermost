using Fluenzi.Mattermost.WebSocket;

namespace Fluenzi.Mattermost;

public class MattermostOptions
{
    public string ServerUrl { get; set; } = string.Empty;
    public TimeSpan DefaultTimeout { get; set; } = TimeSpan.FromMinutes(1);
    public WebSocketClientOptions WebSocket { get; set; } = new();
}
