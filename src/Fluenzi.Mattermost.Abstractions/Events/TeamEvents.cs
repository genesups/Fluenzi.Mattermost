using Fluenzi.Mattermost.Models.Teams;

namespace Fluenzi.Mattermost.Events;

public record AddedToTeamEvent(string TeamId, string UserId) : WebSocketEvent;
public record LeaveTeamEvent(string TeamId, string UserId) : WebSocketEvent;
public record UpdateTeamEvent(Team Team) : WebSocketEvent;
public record DeleteTeamEvent(string TeamId) : WebSocketEvent;
public record RestoreTeamEvent(string TeamId) : WebSocketEvent;
