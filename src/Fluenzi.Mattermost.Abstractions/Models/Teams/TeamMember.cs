using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Teams;

/// <summary>
/// Represents a user's membership in a team.
/// </summary>
public record TeamMember
{
    [JsonPropertyName("team_id")]
    public string TeamId { get; init; } = string.Empty;

    [JsonPropertyName("user_id")]
    public string UserId { get; init; } = string.Empty;

    [JsonPropertyName("roles")]
    public string? Roles { get; init; }

    [JsonPropertyName("delete_at")]
    public long DeleteAt { get; init; }

    [JsonPropertyName("scheme_user")]
    public bool SchemeUser { get; init; }

    [JsonPropertyName("scheme_admin")]
    public bool SchemeAdmin { get; init; }

    [JsonPropertyName("scheme_guest")]
    public bool SchemeGuest { get; init; }

    [JsonPropertyName("explicit_roles")]
    public string? ExplicitRoles { get; init; }

    [JsonPropertyName("mention_count")]
    public long MentionCount { get; init; }

    [JsonPropertyName("mention_count_root")]
    public long MentionCountRoot { get; init; }

    [JsonPropertyName("msg_count")]
    public long MsgCount { get; init; }

    [JsonPropertyName("msg_count_root")]
    public long MsgCountRoot { get; init; }
}
