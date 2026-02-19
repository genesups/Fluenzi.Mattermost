using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Posts;

/// <summary>
/// Represents a field within a post attachment.
/// </summary>
public record PostAttachmentField
{
    [JsonPropertyName("title")]
    public string? Title { get; init; }

    [JsonPropertyName("value")]
    public string? Value { get; init; }

    [JsonPropertyName("short")]
    public bool Short { get; init; }
}
