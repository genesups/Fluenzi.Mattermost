using Fluenzi.Mattermost.Models.Posts;

namespace Fluenzi.Mattermost.Events;

public record PostedEvent(Post Post, string ChannelDisplayName, string TeamId, string ChannelType, string SenderName) : WebSocketEvent;
public record PostEditedEvent(Post Post) : WebSocketEvent;
public record PostDeletedEvent(Post Post) : WebSocketEvent;
public record PostUnreadEvent(string ChannelId, string TeamId, long LastViewedAt, int MsgCount, int MentionCount) : WebSocketEvent;
public record EphemeralMessageEvent(Post Post) : WebSocketEvent;
public record PostAcknowledgementAddedEvent(string PostId, string UserId, long AcknowledgedAt) : WebSocketEvent;
public record PostAcknowledgementRemovedEvent(string PostId, string UserId) : WebSocketEvent;
