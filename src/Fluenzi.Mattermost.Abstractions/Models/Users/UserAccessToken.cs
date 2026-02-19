using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Users;

/// <summary>
/// Represents a personal access token for a user.
/// </summary>
public record UserAccessToken
{
    [JsonPropertyName("id")]
    public string Id { get; init; } = string.Empty;

    [JsonPropertyName("token")]
    public string? Token { get; init; }

    [JsonPropertyName("user_id")]
    public string UserId { get; init; } = string.Empty;

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("is_active")]
    public bool IsActive { get; init; }
}
