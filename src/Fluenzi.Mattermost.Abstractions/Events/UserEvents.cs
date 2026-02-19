using Fluenzi.Mattermost.Models.Users;

namespace Fluenzi.Mattermost.Events;

public record NewUserEvent(string UserId) : WebSocketEvent;
public record UserAddedEvent(string UserId, string ChannelId, string TeamId) : WebSocketEvent;
public record UserUpdatedEvent(User User) : WebSocketEvent;
public record UserRemovedEvent(string UserId, string ChannelId, string RemoverId) : WebSocketEvent;
public record UserRoleUpdatedEvent(string UserId, string Roles) : WebSocketEvent;
public record MemberRoleUpdatedEvent(string UserId, string ChannelId, string Roles) : WebSocketEvent;
public record UserActivationStatusChangeEvent(string UserId, bool Activated) : WebSocketEvent;
public record UserTypingEvent(string UserId, string ChannelId, string? ParentId) : WebSocketEvent;
public record StatusChangeEvent(string UserId, string Status) : WebSocketEvent;
public record PresenceIndicatorEvent(string UserId, string Status) : WebSocketEvent;
