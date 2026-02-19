using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Compliance;

/// <summary>
/// Represents the global data retention policy.
/// </summary>
public record DataRetentionPolicy
{
    [JsonPropertyName("message_deletion_enabled")]
    public bool MessageDeletionEnabled { get; init; }

    [JsonPropertyName("file_deletion_enabled")]
    public bool FileDeletionEnabled { get; init; }

    [JsonPropertyName("message_retention_cutoff")]
    public long MessageRetentionDays { get; init; }

    [JsonPropertyName("file_retention_cutoff")]
    public long FileRetentionDays { get; init; }

    [JsonPropertyName("deletion_job_start_time")]
    public string? DeletionJobStartTime { get; init; }
}
