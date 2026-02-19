using System.Text.Json;
using Fluenzi.Mattermost.Constants;
using Fluenzi.Mattermost.Enums;
using Fluenzi.Mattermost.Events;
using Fluenzi.Mattermost.Models.Channels;
using Fluenzi.Mattermost.Models.Posts;
using Fluenzi.Mattermost.Models.Preferences;
using Fluenzi.Mattermost.Models.Reactions;
using Fluenzi.Mattermost.Models.Users;
using Microsoft.Extensions.Logging;

namespace Fluenzi.Mattermost.WebSocket.Internal;

internal sealed class EventDeserializer
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        PropertyNameCaseInsensitive = true
    };

    private readonly ILogger _logger;

    public EventDeserializer(ILogger logger) => _logger = logger;

    public WebSocketEventEnvelope? ParseEnvelope(ReadOnlyMemory<byte> message)
    {
        try
        {
            using var doc = JsonDocument.Parse(message);
            var root = doc.RootElement;

            var eventName = root.TryGetProperty("event", out var evt) ? evt.GetString() ?? "" : "";
            var seq = root.TryGetProperty("seq", out var s) ? s.GetInt32() : 0;
            var data = root.TryGetProperty("data", out var d) ? d.Clone() : default;
            var broadcast = root.TryGetProperty("broadcast", out var b) ? b.Clone() : default;

            var eventType = WebSocketEventNames.Parse(eventName);

            return new WebSocketEventEnvelope(eventType, eventName, seq, data, broadcast);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Failed to parse WebSocket message");
            return null;
        }
    }

    public WebSocketEvent? DeserializeEvent(WebSocketEventEnvelope envelope)
    {
        try
        {
            return envelope.EventType switch
            {
                WebSocketEventType.Posted => DeserializePosted(envelope.Data),
                WebSocketEventType.PostEdited => DeserializePostEdited(envelope.Data),
                WebSocketEventType.PostDeleted => DeserializePostDeleted(envelope.Data),
                WebSocketEventType.PostUnread => DeserializePostUnread(envelope.Data),
                WebSocketEventType.ReactionAdded => DeserializeReaction<ReactionAddedEvent>(envelope.Data),
                WebSocketEventType.ReactionRemoved => DeserializeReaction<ReactionRemovedEvent>(envelope.Data),
                WebSocketEventType.Typing => DeserializeTyping(envelope.Data),
                WebSocketEventType.StatusChange => DeserializeStatusChange(envelope.Data),
                WebSocketEventType.UserUpdated => DeserializeUserUpdated(envelope.Data),
                WebSocketEventType.UserAdded => DeserializeUserAdded(envelope.Data),
                WebSocketEventType.UserRemoved => DeserializeUserRemoved(envelope.Data),
                WebSocketEventType.ChannelCreated => DeserializeSimple<ChannelCreatedEvent>(envelope.Data),
                WebSocketEventType.ChannelUpdated => DeserializeChannelUpdated(envelope.Data),
                WebSocketEventType.ChannelDeleted => DeserializeSimple<ChannelDeletedEvent>(envelope.Data),
                WebSocketEventType.ChannelViewed => DeserializeSimple<ChannelViewedEvent>(envelope.Data),
                WebSocketEventType.DirectAdded => DeserializeSimple<DirectAddedEvent>(envelope.Data),
                WebSocketEventType.GroupAdded => DeserializeSimple<GroupAddedEvent>(envelope.Data),
                WebSocketEventType.ThreadUpdated => DeserializeSimple<ThreadUpdatedEvent>(envelope.Data),
                WebSocketEventType.ThreadFollowChanged => DeserializeSimple<ThreadFollowChangedEvent>(envelope.Data),
                WebSocketEventType.ThreadReadChanged => DeserializeSimple<ThreadReadChangedEvent>(envelope.Data),
                WebSocketEventType.PreferencesChanged => DeserializePreferencesChanged(envelope.Data),
                WebSocketEventType.PreferencesDeleted => DeserializePreferencesDeleted(envelope.Data),
                WebSocketEventType.Hello => new HelloEvent(
                    envelope.Data.TryGetProperty("connection_id", out var cid2) ? cid2.GetString() ?? "" : "",
                    envelope.Data.TryGetProperty("server_version", out var sv) ? sv.GetString() ?? "" : ""),
                _ => null
            };
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Failed to deserialize event {EventType}", envelope.EventType);
            return null;
        }
    }

    private PostedEvent? DeserializePosted(JsonElement data)
    {
        var postJson = data.GetProperty("post").GetString();
        if (postJson == null) return null;
        var post = JsonSerializer.Deserialize<Post>(postJson, JsonOptions);
        if (post == null) return null;

        return new PostedEvent(
            post,
            data.TryGetProperty("channel_display_name", out var cdn) ? cdn.GetString() ?? "" : "",
            data.TryGetProperty("team_id", out var tid) ? tid.GetString() ?? "" : "",
            data.TryGetProperty("channel_type", out var ct) ? ct.GetString() ?? "" : "",
            data.TryGetProperty("sender_name", out var sn) ? sn.GetString() ?? "" : "");
    }

    private PostEditedEvent? DeserializePostEdited(JsonElement data)
    {
        var postJson = data.GetProperty("post").GetString();
        if (postJson == null) return null;
        var post = JsonSerializer.Deserialize<Post>(postJson, JsonOptions);
        return post != null ? new PostEditedEvent(post) : null;
    }

    private PostDeletedEvent? DeserializePostDeleted(JsonElement data)
    {
        var postJson = data.GetProperty("post").GetString();
        if (postJson == null) return null;
        var post = JsonSerializer.Deserialize<Post>(postJson, JsonOptions);
        return post != null ? new PostDeletedEvent(post) : null;
    }

    private PostUnreadEvent DeserializePostUnread(JsonElement data)
    {
        return new PostUnreadEvent(
            data.TryGetProperty("channel_id", out var cid) ? cid.GetString() ?? "" : "",
            data.TryGetProperty("team_id", out var tid) ? tid.GetString() ?? "" : "",
            data.TryGetProperty("last_viewed_at", out var lva) ? lva.GetInt64() : 0,
            data.TryGetProperty("msg_count", out var mc) ? mc.GetInt32() : 0,
            data.TryGetProperty("mention_count", out var mnc) ? mnc.GetInt32() : 0);
    }

    private WebSocketEvent? DeserializeReaction<T>(JsonElement data) where T : WebSocketEvent
    {
        var reactionJson = data.TryGetProperty("reaction", out var r) ? r.GetString() : null;
        if (reactionJson == null) return null;
        var reaction = JsonSerializer.Deserialize<Reaction>(reactionJson, JsonOptions);
        if (reaction == null) return null;

        if (typeof(T) == typeof(ReactionAddedEvent))
            return new ReactionAddedEvent(reaction);
        return new ReactionRemovedEvent(reaction);
    }

    private UserTypingEvent DeserializeTyping(JsonElement data)
    {
        return new UserTypingEvent(
            data.TryGetProperty("user_id", out var uid) ? uid.GetString() ?? "" : "",
            data.TryGetProperty("channel_id", out var cid) ? cid.GetString() ?? "" : "",
            data.TryGetProperty("parent_id", out var pid) ? pid.GetString() : null);
    }

    private StatusChangeEvent DeserializeStatusChange(JsonElement data)
    {
        return new StatusChangeEvent(
            data.TryGetProperty("user_id", out var uid) ? uid.GetString() ?? "" : "",
            data.TryGetProperty("status", out var s) ? s.GetString() ?? "" : "");
    }

    private UserUpdatedEvent? DeserializeUserUpdated(JsonElement data)
    {
        if (!data.TryGetProperty("user", out var userEl)) return null;
        var user = JsonSerializer.Deserialize<User>(userEl.GetRawText(), JsonOptions);
        return user != null ? new UserUpdatedEvent(user) : null;
    }

    private UserAddedEvent DeserializeUserAdded(JsonElement data)
    {
        return new UserAddedEvent(
            data.TryGetProperty("user_id", out var uid) ? uid.GetString() ?? "" : "",
            data.TryGetProperty("channel_id", out var cid) ? cid.GetString() ?? "" : "",
            data.TryGetProperty("team_id", out var tid) ? tid.GetString() ?? "" : "");
    }

    private UserRemovedEvent DeserializeUserRemoved(JsonElement data)
    {
        return new UserRemovedEvent(
            data.TryGetProperty("user_id", out var uid) ? uid.GetString() ?? "" : "",
            data.TryGetProperty("channel_id", out var cid) ? cid.GetString() ?? "" : "",
            data.TryGetProperty("remover_id", out var rid) ? rid.GetString() ?? "" : "");
    }

    private ChannelUpdatedEvent? DeserializeChannelUpdated(JsonElement data)
    {
        var channelJson = data.TryGetProperty("channel", out var c) ? c.GetString() : null;
        if (channelJson == null) return null;
        var channel = JsonSerializer.Deserialize<Channel>(channelJson, JsonOptions);
        return channel != null ? new ChannelUpdatedEvent(channel) : null;
    }

    private PreferencesChangedEvent? DeserializePreferencesChanged(JsonElement data)
    {
        var prefsJson = data.TryGetProperty("preferences", out var p) ? p.GetString() : null;
        if (prefsJson == null) return null;
        var prefs = JsonSerializer.Deserialize<Preference[]>(prefsJson, JsonOptions);
        return prefs != null ? new PreferencesChangedEvent(prefs) : null;
    }

    private PreferencesDeletedEvent? DeserializePreferencesDeleted(JsonElement data)
    {
        var prefsJson = data.TryGetProperty("preferences", out var p) ? p.GetString() : null;
        if (prefsJson == null) return null;
        var prefs = JsonSerializer.Deserialize<Preference[]>(prefsJson, JsonOptions);
        return prefs != null ? new PreferencesDeletedEvent(prefs) : null;
    }

    private T? DeserializeSimple<T>(JsonElement data) where T : class
    {
        try
        {
            return JsonSerializer.Deserialize<T>(data.GetRawText(), JsonOptions);
        }
        catch
        {
            return null;
        }
    }
}
