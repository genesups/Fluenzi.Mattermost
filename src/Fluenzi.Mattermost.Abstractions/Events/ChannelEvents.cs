using Fluenzi.Mattermost.Models.Channels;

namespace Fluenzi.Mattermost.Events;

public record ChannelCreatedEvent(string ChannelId, string TeamId) : WebSocketEvent;
public record ChannelUpdatedEvent(Channel Channel) : WebSocketEvent;
public record ChannelDeletedEvent(string ChannelId, string TeamId) : WebSocketEvent;
public record ChannelConvertedEvent(string ChannelId) : WebSocketEvent;
public record ChannelViewedEvent(string ChannelId) : WebSocketEvent;
public record ChannelMemberUpdatedEvent(ChannelMember Member) : WebSocketEvent;
public record ChannelRestoredEvent(string ChannelId, string TeamId) : WebSocketEvent;
public record DirectAddedEvent(string ChannelId, string TeamId) : WebSocketEvent;
public record GroupAddedEvent(string ChannelId, string TeamId) : WebSocketEvent;
public record MultipleChannelsViewedEvent(IReadOnlyList<string> ChannelIds) : WebSocketEvent;
