using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Users;

/// <summary>
/// Represents the online/offline status of a user.
/// </summary>
public record UserStatus
{
    [JsonPropertyName("user_id")]
    public string UserId { get; init; } = string.Empty;

    [JsonPropertyName("status")]
    public string Status { get; init; } = string.Empty;

    [JsonPropertyName("manual")]
    public bool Manual { get; init; }

    [JsonPropertyName("last_activity_at")]
    public long LastActivityAt { get; init; }

    [JsonPropertyName("dnd_end_time")]
    public long DndEndTime { get; init; }

    [JsonPropertyName("active_channel")]
    public string? ActiveChannel { get; init; }
}
