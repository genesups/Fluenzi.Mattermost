using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Channels;

/// <summary>
/// Represents a bookmark pinned to a channel.
/// </summary>
public record ChannelBookmark
{
    [JsonPropertyName("id")]
    public string Id { get; init; } = string.Empty;

    [JsonPropertyName("channel_id")]
    public string ChannelId { get; init; } = string.Empty;

    [JsonPropertyName("create_at")]
    public long CreateAt { get; init; }

    [JsonPropertyName("update_at")]
    public long UpdateAt { get; init; }

    [JsonPropertyName("delete_at")]
    public long DeleteAt { get; init; }

    [JsonPropertyName("owner_id")]
    public string? OwnerId { get; init; }

    [JsonPropertyName("file_id")]
    public string? FileId { get; init; }

    [JsonPropertyName("display_name")]
    public string DisplayName { get; init; } = string.Empty;

    [JsonPropertyName("sort_order")]
    public long SortOrder { get; init; }

    [JsonPropertyName("link_url")]
    public string? LinkUrl { get; init; }

    [JsonPropertyName("image_url")]
    public string? ImageUrl { get; init; }

    [JsonPropertyName("emoji")]
    public string? Emoji { get; init; }

    [JsonPropertyName("type")]
    public string Type { get; init; } = string.Empty;
}
