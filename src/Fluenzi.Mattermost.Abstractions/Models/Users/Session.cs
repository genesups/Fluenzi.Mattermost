using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Users;

/// <summary>
/// Represents an active user session.
/// </summary>
public record Session
{
    [JsonPropertyName("id")]
    public string Id { get; init; } = string.Empty;

    [JsonPropertyName("token")]
    public string? Token { get; init; }

    [JsonPropertyName("user_id")]
    public string UserId { get; init; } = string.Empty;

    [JsonPropertyName("device_id")]
    public string? DeviceId { get; init; }

    [JsonPropertyName("roles")]
    public string? Roles { get; init; }

    [JsonPropertyName("is_oauth")]
    public bool IsOAuth { get; init; }

    [JsonPropertyName("props")]
    public Dictionary<string, string>? Props { get; init; }

    [JsonPropertyName("create_at")]
    public long CreateAt { get; init; }

    [JsonPropertyName("expires_at")]
    public long ExpiresAt { get; init; }

    [JsonPropertyName("last_activity_at")]
    public long LastActivityAt { get; init; }
}
