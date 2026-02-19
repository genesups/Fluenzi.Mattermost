using Fluenzi.Mattermost.Events;
using Fluenzi.Mattermost.Interfaces.Store;
using Fluenzi.Mattermost.Interfaces.WebSocket;
using Fluenzi.Mattermost.Models.Preferences;
using Microsoft.Extensions.Logging;

namespace Fluenzi.Mattermost.Store;

public class StoreReducer : IDisposable
{
    private readonly IMattermostStore _store;
    private readonly IWebSocketEventStream _eventStream;
    private readonly ILogger<StoreReducer> _logger;
    private IDisposable? _subscription;

    public StoreReducer(IMattermostStore store, IWebSocketEventStream eventStream, ILogger<StoreReducer> logger)
    {
        _store = store;
        _eventStream = eventStream;
        _logger = logger;
    }

    public void Start()
    {
        _subscription?.Dispose();
        _subscription = _eventStream.Events.Subscribe(envelope =>
        {
            try
            {
                DispatchEvent(envelope);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error dispatching event {EventType}", envelope.EventType);
            }
        });
    }

    private void DispatchEvent(WebSocketEventEnvelope envelope)
    {
        // Use the event stream's typed deserialization
        switch (envelope.EventType)
        {
            case Enums.WebSocketEventType.Posted:
            case Enums.WebSocketEventType.PostEdited:
                HandlePostUpsert(envelope);
                break;
            case Enums.WebSocketEventType.PostDeleted:
                HandlePostDeleted(envelope);
                break;
            case Enums.WebSocketEventType.StatusChange:
                HandleStatusChange(envelope);
                break;
            case Enums.WebSocketEventType.UserUpdated:
                HandleUserUpdated(envelope);
                break;
            case Enums.WebSocketEventType.Typing:
                HandleTyping(envelope);
                break;
            case Enums.WebSocketEventType.ReactionAdded:
                HandleReactionAdded(envelope);
                break;
            case Enums.WebSocketEventType.ReactionRemoved:
                HandleReactionRemoved(envelope);
                break;
            case Enums.WebSocketEventType.ChannelUpdated:
                HandleChannelUpdated(envelope);
                break;
            case Enums.WebSocketEventType.PreferencesChanged:
                HandlePreferencesChanged(envelope);
                break;
            case Enums.WebSocketEventType.PreferencesDeleted:
                HandlePreferencesDeleted(envelope);
                break;
        }
    }

    private void HandlePostUpsert(WebSocketEventEnvelope envelope)
    {
        try
        {
            var postJson = envelope.Data.GetProperty("post").GetString();
            if (postJson == null) return;
            var post = System.Text.Json.JsonSerializer.Deserialize<Models.Posts.Post>(postJson, JsonOptions);
            if (post?.Id != null)
                _store.Posts.Upsert(post.Id, post);
        }
        catch (Exception ex) { _logger.LogDebug(ex, "Failed to handle post upsert"); }
    }

    private void HandlePostDeleted(WebSocketEventEnvelope envelope)
    {
        try
        {
            var postJson = envelope.Data.GetProperty("post").GetString();
            if (postJson == null) return;
            var post = System.Text.Json.JsonSerializer.Deserialize<Models.Posts.Post>(postJson, JsonOptions);
            if (post?.Id != null)
                _store.Posts.Remove(post.Id);
        }
        catch (Exception ex) { _logger.LogDebug(ex, "Failed to handle post delete"); }
    }

    private void HandleStatusChange(WebSocketEventEnvelope envelope)
    {
        try
        {
            var userId = envelope.Data.GetProperty("user_id").GetString();
            var status = envelope.Data.GetProperty("status").GetString();
            if (userId != null && status != null)
            {
                _store.Statuses.Upsert(userId, new Models.Users.UserStatus
                {
                    UserId = userId,
                    Status = status
                });
            }
        }
        catch (Exception ex) { _logger.LogDebug(ex, "Failed to handle status change"); }
    }

    private void HandleUserUpdated(WebSocketEventEnvelope envelope)
    {
        try
        {
            if (envelope.Data.TryGetProperty("user", out var userEl))
            {
                var user = System.Text.Json.JsonSerializer.Deserialize<Models.Users.User>(userEl.GetRawText(), JsonOptions);
                if (user?.Id != null)
                    _store.Users.Upsert(user.Id, user);
            }
        }
        catch (Exception ex) { _logger.LogDebug(ex, "Failed to handle user update"); }
    }

    private void HandleTyping(WebSocketEventEnvelope envelope)
    {
        try
        {
            var userId = envelope.Data.GetProperty("user_id").GetString();
            var channelId = envelope.Data.GetProperty("channel_id").GetString();
            if (userId != null && channelId != null)
                _store.Typing.AddTyping(userId, channelId);
        }
        catch (Exception ex) { _logger.LogDebug(ex, "Failed to handle typing"); }
    }

    private void HandleReactionAdded(WebSocketEventEnvelope envelope)
    {
        try
        {
            var reactionJson = envelope.Data.GetProperty("reaction").GetString();
            if (reactionJson == null) return;
            var reaction = System.Text.Json.JsonSerializer.Deserialize<Models.Reactions.Reaction>(reactionJson, JsonOptions);
            if (reaction != null)
                _store.Reactions.AddReaction(reaction);
        }
        catch (Exception ex) { _logger.LogDebug(ex, "Failed to handle reaction added"); }
    }

    private void HandleReactionRemoved(WebSocketEventEnvelope envelope)
    {
        try
        {
            var reactionJson = envelope.Data.GetProperty("reaction").GetString();
            if (reactionJson == null) return;
            var reaction = System.Text.Json.JsonSerializer.Deserialize<Models.Reactions.Reaction>(reactionJson, JsonOptions);
            if (reaction?.UserId != null && reaction.PostId != null && reaction.EmojiName != null)
                _store.Reactions.RemoveReaction(reaction.UserId, reaction.PostId, reaction.EmojiName);
        }
        catch (Exception ex) { _logger.LogDebug(ex, "Failed to handle reaction removed"); }
    }

    private void HandleChannelUpdated(WebSocketEventEnvelope envelope)
    {
        try
        {
            var channelJson = envelope.Data.GetProperty("channel").GetString();
            if (channelJson == null) return;
            var channel = System.Text.Json.JsonSerializer.Deserialize<Models.Channels.Channel>(channelJson, JsonOptions);
            if (channel?.Id != null)
                _store.Channels.Upsert(channel.Id, channel);
        }
        catch (Exception ex) { _logger.LogDebug(ex, "Failed to handle channel update"); }
    }

    private void HandlePreferencesChanged(WebSocketEventEnvelope envelope)
    {
        try
        {
            var prefsJson = envelope.Data.GetProperty("preferences").GetString();
            if (prefsJson == null) return;
            var prefs = System.Text.Json.JsonSerializer.Deserialize<Preference[]>(prefsJson, JsonOptions);
            if (prefs == null) return;
            foreach (var p in prefs)
            {
                var key = $"{p.UserId}:{p.Category}:{p.Name}";
                _store.Preferences.Upsert(key, p);
            }
        }
        catch (Exception ex) { _logger.LogDebug(ex, "Failed to handle preferences changed"); }
    }

    private void HandlePreferencesDeleted(WebSocketEventEnvelope envelope)
    {
        try
        {
            var prefsJson = envelope.Data.GetProperty("preferences").GetString();
            if (prefsJson == null) return;
            var prefs = System.Text.Json.JsonSerializer.Deserialize<Preference[]>(prefsJson, JsonOptions);
            if (prefs == null) return;
            foreach (var p in prefs)
            {
                var key = $"{p.UserId}:{p.Category}:{p.Name}";
                _store.Preferences.Remove(key);
            }
        }
        catch (Exception ex) { _logger.LogDebug(ex, "Failed to handle preferences deleted"); }
    }

    private static readonly System.Text.Json.JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.SnakeCaseLower,
        PropertyNameCaseInsensitive = true
    };

    public void Dispose()
    {
        _subscription?.Dispose();
    }
}
