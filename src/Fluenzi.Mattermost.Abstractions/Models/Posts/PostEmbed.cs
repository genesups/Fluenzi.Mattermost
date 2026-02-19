using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Posts;

/// <summary>
/// Represents an embedded link preview in a post.
/// </summary>
public record PostEmbed
{
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("url")]
    public string? Url { get; init; }

    [JsonPropertyName("data")]
    public object? Data { get; init; }
}
