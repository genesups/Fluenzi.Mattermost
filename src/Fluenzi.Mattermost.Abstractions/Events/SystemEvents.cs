namespace Fluenzi.Mattermost.Events;

public record HelloEvent(string ConnectionId, string ServerVersion) : WebSocketEvent;
public record LicenseChangedEvent() : WebSocketEvent;
public record ConfigChangedEvent() : WebSocketEvent;
public record OpenDialogEvent(string TriggerId, string Url, Dictionary<string, object> Dialog) : WebSocketEvent;
public record EmojiAddedEvent(string EmojiId) : WebSocketEvent;
public record RoleUpdatedEvent(string RoleId) : WebSocketEvent;
public record PluginStatusesChangedEvent() : WebSocketEvent;
