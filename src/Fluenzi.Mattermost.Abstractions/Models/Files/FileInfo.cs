using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Files;

/// <summary>
/// Represents metadata about a file attached to a post.
/// </summary>
public record FileInfo
{
    [JsonPropertyName("id")]
    public string Id { get; init; } = string.Empty;

    [JsonPropertyName("user_id")]
    public string UserId { get; init; } = string.Empty;

    [JsonPropertyName("post_id")]
    public string? PostId { get; init; }

    [JsonPropertyName("channel_id")]
    public string? ChannelId { get; init; }

    [JsonPropertyName("create_at")]
    public long CreateAt { get; init; }

    [JsonPropertyName("update_at")]
    public long UpdateAt { get; init; }

    [JsonPropertyName("delete_at")]
    public long DeleteAt { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    [JsonPropertyName("extension")]
    public string? Extension { get; init; }

    [JsonPropertyName("size")]
    public long Size { get; init; }

    [JsonPropertyName("mime_type")]
    public string? MimeType { get; init; }

    [JsonPropertyName("width")]
    public int Width { get; init; }

    [JsonPropertyName("height")]
    public int Height { get; init; }

    [JsonPropertyName("has_preview_image")]
    public bool HasPreviewImage { get; init; }

    [JsonPropertyName("mini_preview")]
    public string? MiniPreview { get; init; }

    [JsonPropertyName("remote_id")]
    public string? RemoteId { get; init; }

    [JsonPropertyName("archived")]
    public bool Archived { get; init; }
}
