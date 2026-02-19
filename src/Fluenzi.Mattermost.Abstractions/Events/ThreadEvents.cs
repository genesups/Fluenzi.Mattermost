using Fluenzi.Mattermost.Models.Threads;

namespace Fluenzi.Mattermost.Events;

public record ThreadUpdatedEvent(UserThread Thread) : WebSocketEvent;
public record ThreadFollowChangedEvent(string ThreadId, string TeamId, bool Following) : WebSocketEvent;
public record ThreadReadChangedEvent(string ThreadId, string TeamId, long Timestamp, int UnreadMentions, int UnreadReplies) : WebSocketEvent;
