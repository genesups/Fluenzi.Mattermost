namespace Fluenzi.Mattermost.WebSocket;

public class WebSocketClientOptions
{
    public TimeSpan HeartbeatInterval { get; set; } = TimeSpan.FromSeconds(30);
    public TimeSpan PongTimeout { get; set; } = TimeSpan.FromSeconds(10);
    public TimeSpan ReconnectMinDelay { get; set; } = TimeSpan.FromSeconds(1);
    public TimeSpan ReconnectMaxDelay { get; set; } = TimeSpan.FromSeconds(30);
    public int MaxReconnectAttempts { get; set; } = int.MaxValue;
    public int ReceiveBufferSize { get; set; } = 8192;
    public int MaxMessageSize { get; set; } = 4 * 1024 * 1024; // 4MB
}
