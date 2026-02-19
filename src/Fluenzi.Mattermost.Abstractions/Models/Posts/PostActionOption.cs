using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Posts;

/// <summary>
/// Represents an option in a post action select menu.
/// </summary>
public record PostActionOption
{
    [JsonPropertyName("text")]
    public string? Text { get; init; }

    [JsonPropertyName("value")]
    public string? Value { get; init; }
}
