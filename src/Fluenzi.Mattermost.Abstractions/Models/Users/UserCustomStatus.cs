using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Users;

/// <summary>
/// Represents a user's custom status (emoji + text).
/// </summary>
public record UserCustomStatus
{
    [JsonPropertyName("emoji")]
    public string? Emoji { get; init; }

    [JsonPropertyName("text")]
    public string? Text { get; init; }

    [JsonPropertyName("duration")]
    public string? Duration { get; init; }

    [JsonPropertyName("expires_at")]
    public string? ExpiresAt { get; init; }
}
