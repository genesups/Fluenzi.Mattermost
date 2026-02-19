using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Compliance;

/// <summary>
/// Represents an entry in the audit log.
/// </summary>
public record AuditEntry
{
    [JsonPropertyName("id")]
    public string Id { get; init; } = string.Empty;

    [JsonPropertyName("create_at")]
    public long CreateAt { get; init; }

    [JsonPropertyName("user_id")]
    public string UserId { get; init; } = string.Empty;

    [JsonPropertyName("action")]
    public string? Action { get; init; }

    [JsonPropertyName("extra_info")]
    public string? ExtraInfo { get; init; }

    [JsonPropertyName("ip_address")]
    public string? IpAddress { get; init; }

    [JsonPropertyName("session_id")]
    public string? SessionId { get; init; }
}
