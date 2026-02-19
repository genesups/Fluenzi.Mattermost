using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Posts;

/// <summary>
/// Represents the integration endpoint for a post action.
/// </summary>
public record PostActionIntegration
{
    [JsonPropertyName("url")]
    public string? Url { get; init; }

    [JsonPropertyName("context")]
    public Dictionary<string, object>? Context { get; init; }
}
