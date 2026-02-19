using Fluenzi.Mattermost.Models.Reactions;

namespace Fluenzi.Mattermost.Events;

public record ReactionAddedEvent(Reaction Reaction) : WebSocketEvent;
public record ReactionRemovedEvent(Reaction Reaction) : WebSocketEvent;
