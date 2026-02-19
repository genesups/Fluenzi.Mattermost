using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Compliance;

/// <summary>
/// Represents a compliance report.
/// </summary>
public record ComplianceReport
{
    [JsonPropertyName("id")]
    public string Id { get; init; } = string.Empty;

    [JsonPropertyName("create_at")]
    public long CreateAt { get; init; }

    [JsonPropertyName("user_id")]
    public string UserId { get; init; } = string.Empty;

    [JsonPropertyName("status")]
    public string? Status { get; init; }

    [JsonPropertyName("count")]
    public long Count { get; init; }

    [JsonPropertyName("desc")]
    public string? Desc { get; init; }

    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("start_at")]
    public long StartAt { get; init; }

    [JsonPropertyName("end_at")]
    public long EndAt { get; init; }
}
