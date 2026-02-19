using Fluenzi.Mattermost.Models.Channels;

namespace Fluenzi.Mattermost.Events;

public record SidebarCategoryCreatedEvent(ChannelCategory Category) : WebSocketEvent;
public record SidebarCategoryUpdatedEvent(ChannelCategory Category) : WebSocketEvent;
public record SidebarCategoryDeletedEvent(string CategoryId, string TeamId) : WebSocketEvent;
public record SidebarCategoryOrderUpdatedEvent(string TeamId, IReadOnlyList<string> Order) : WebSocketEvent;
