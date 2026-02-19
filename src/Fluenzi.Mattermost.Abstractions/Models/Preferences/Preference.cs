using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Preferences;

/// <summary>
/// Represents a user preference entry.
/// </summary>
public record Preference
{
    [JsonPropertyName("user_id")]
    public string UserId { get; init; } = string.Empty;

    [JsonPropertyName("category")]
    public string Category { get; init; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    [JsonPropertyName("value")]
    public string? Value { get; init; }
}
