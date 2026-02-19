namespace Fluenzi.Mattermost.Events;

public record DraftCreatedEvent(string UserId, string ChannelId, string? RootId) : WebSocketEvent;
public record DraftUpdatedEvent(string UserId, string ChannelId, string? RootId) : WebSocketEvent;
public record DraftDeletedEvent(string UserId, string ChannelId, string? RootId) : WebSocketEvent;
