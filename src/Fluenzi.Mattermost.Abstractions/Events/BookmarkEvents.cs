using Fluenzi.Mattermost.Models.Channels;

namespace Fluenzi.Mattermost.Events;

public record ChannelBookmarkCreatedEvent(ChannelBookmark Bookmark) : WebSocketEvent;
public record ChannelBookmarkUpdatedEvent(ChannelBookmark Bookmark) : WebSocketEvent;
public record ChannelBookmarkDeletedEvent(string BookmarkId, string ChannelId) : WebSocketEvent;
public record ChannelBookmarkSortedEvent(string ChannelId, IReadOnlyList<string> BookmarkIds) : WebSocketEvent;
