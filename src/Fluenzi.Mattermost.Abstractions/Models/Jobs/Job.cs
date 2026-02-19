using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Jobs;

/// <summary>
/// Represents a background job on the server.
/// </summary>
public record Job
{
    [JsonPropertyName("id")]
    public string Id { get; init; } = string.Empty;

    [JsonPropertyName("type")]
    public string Type { get; init; } = string.Empty;

    [JsonPropertyName("priority")]
    public int Priority { get; init; }

    [JsonPropertyName("create_at")]
    public long CreateAt { get; init; }

    [JsonPropertyName("start_at")]
    public long StartAt { get; init; }

    [JsonPropertyName("last_activity_at")]
    public long LastActivityAt { get; init; }

    [JsonPropertyName("status")]
    public string? Status { get; init; }

    [JsonPropertyName("progress")]
    public long Progress { get; init; }

    [JsonPropertyName("data")]
    public Dictionary<string, string>? Data { get; init; }
}
