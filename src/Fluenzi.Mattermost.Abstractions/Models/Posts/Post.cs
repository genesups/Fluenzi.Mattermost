using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Posts;

/// <summary>
/// Represents a Mattermost post (message).
/// </summary>
public record Post
{
    [JsonPropertyName("id")]
    public string Id { get; init; } = string.Empty;

    [JsonPropertyName("create_at")]
    public long CreateAt { get; init; }

    [JsonPropertyName("update_at")]
    public long UpdateAt { get; init; }

    [JsonPropertyName("edit_at")]
    public long EditAt { get; init; }

    [JsonPropertyName("delete_at")]
    public long DeleteAt { get; init; }

    [JsonPropertyName("is_pinned")]
    public bool IsPinned { get; init; }

    [JsonPropertyName("user_id")]
    public string UserId { get; init; } = string.Empty;

    [JsonPropertyName("channel_id")]
    public string ChannelId { get; init; } = string.Empty;

    [JsonPropertyName("root_id")]
    public string? RootId { get; init; }

    [JsonPropertyName("original_id")]
    public string? OriginalId { get; init; }

    [JsonPropertyName("message")]
    public string Message { get; init; } = string.Empty;

    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("hashtags")]
    public string? Hashtags { get; init; }

    [JsonPropertyName("file_ids")]
    public string[]? FileIds { get; init; }

    [JsonPropertyName("pending_post_id")]
    public string? PendingPostId { get; init; }

    [JsonPropertyName("reply_count")]
    public int ReplyCount { get; init; }

    [JsonPropertyName("metadata")]
    public PostMetadata? Metadata { get; init; }

    [JsonPropertyName("is_following")]
    public bool? IsFollowing { get; init; }

    [JsonPropertyName("props")]
    public Dictionary<string, object>? Props { get; init; }

    [JsonPropertyName("participants")]
    public string[]? Participants { get; init; }
}
