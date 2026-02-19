using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Posts;

/// <summary>
/// Represents a message attachment on a post (Slack-compatible).
/// </summary>
public record PostAttachment
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("fallback")]
    public string? Fallback { get; init; }

    [JsonPropertyName("color")]
    public string? Color { get; init; }

    [JsonPropertyName("pretext")]
    public string? Pretext { get; init; }

    [JsonPropertyName("author_name")]
    public string? AuthorName { get; init; }

    [JsonPropertyName("author_icon")]
    public string? AuthorIcon { get; init; }

    [JsonPropertyName("author_link")]
    public string? AuthorLink { get; init; }

    [JsonPropertyName("title")]
    public string? Title { get; init; }

    [JsonPropertyName("title_link")]
    public string? TitleLink { get; init; }

    [JsonPropertyName("text")]
    public string? Text { get; init; }

    [JsonPropertyName("fields")]
    public PostAttachmentField[]? Fields { get; init; }

    [JsonPropertyName("image_url")]
    public string? ImageUrl { get; init; }

    [JsonPropertyName("thumb_url")]
    public string? ThumbUrl { get; init; }

    [JsonPropertyName("footer")]
    public string? Footer { get; init; }

    [JsonPropertyName("footer_icon")]
    public string? FooterIcon { get; init; }

    [JsonPropertyName("timestamp")]
    public long Timestamp { get; init; }

    [JsonPropertyName("actions")]
    public PostAction[]? Actions { get; init; }
}
