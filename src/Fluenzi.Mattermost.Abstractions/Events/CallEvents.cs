namespace Fluenzi.Mattermost.Events;

public record CallStartedEvent(string ChannelId, string UserId) : WebSocketEvent;
public record CallEndedEvent(string ChannelId) : WebSocketEvent;
public record CallUserJoinedEvent(string ChannelId, string UserId) : WebSocketEvent;
public record CallUserLeftEvent(string ChannelId, string UserId) : WebSocketEvent;
