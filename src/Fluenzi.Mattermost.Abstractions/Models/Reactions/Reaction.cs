using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Reactions;

/// <summary>
/// Represents an emoji reaction on a post.
/// </summary>
public record Reaction
{
    [JsonPropertyName("user_id")]
    public string UserId { get; init; } = string.Empty;

    [JsonPropertyName("post_id")]
    public string PostId { get; init; } = string.Empty;

    [JsonPropertyName("emoji_name")]
    public string EmojiName { get; init; } = string.Empty;

    [JsonPropertyName("create_at")]
    public long CreateAt { get; init; }

    [JsonPropertyName("update_at")]
    public long UpdateAt { get; init; }

    [JsonPropertyName("delete_at")]
    public long DeleteAt { get; init; }

    [JsonPropertyName("remote_id")]
    public string? RemoteId { get; init; }
}
