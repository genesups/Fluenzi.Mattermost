using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Users;

/// <summary>
/// Represents a user's timezone settings.
/// </summary>
public record UserTimezone
{
    [JsonPropertyName("useAutomaticTimezone")]
    public string? UseAutomaticTimezone { get; init; }

    [JsonPropertyName("manualTimezone")]
    public string? ManualTimezone { get; init; }

    [JsonPropertyName("automaticTimezone")]
    public string? AutomaticTimezone { get; init; }
}
