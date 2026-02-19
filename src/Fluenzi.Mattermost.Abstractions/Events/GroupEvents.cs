using Fluenzi.Mattermost.Models.Groups;

namespace Fluenzi.Mattermost.Events;

public record ReceivedGroupEvent(Group Group) : WebSocketEvent;
public record GroupMemberAddEvent(string GroupId, string UserId) : WebSocketEvent;
public record GroupMemberDeleteEvent(string GroupId, string UserId) : WebSocketEvent;
