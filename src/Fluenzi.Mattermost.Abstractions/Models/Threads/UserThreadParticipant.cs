using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Threads;

/// <summary>
/// Represents a participant in a thread.
/// </summary>
public record UserThreadParticipant
{
    [JsonPropertyName("id")]
    public string Id { get; init; } = string.Empty;

    [JsonPropertyName("last_update_at")]
    public long LastUpdateAt { get; init; }
}
