using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Teams;

/// <summary>
/// Represents a Mattermost team.
/// </summary>
public record Team
{
    [JsonPropertyName("id")]
    public string Id { get; init; } = string.Empty;

    [JsonPropertyName("create_at")]
    public long CreateAt { get; init; }

    [JsonPropertyName("update_at")]
    public long UpdateAt { get; init; }

    [JsonPropertyName("delete_at")]
    public long DeleteAt { get; init; }

    [JsonPropertyName("display_name")]
    public string DisplayName { get; init; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("email")]
    public string? Email { get; init; }

    [JsonPropertyName("type")]
    public string Type { get; init; } = string.Empty;

    [JsonPropertyName("allowed_domains")]
    public string? AllowedDomains { get; init; }

    [JsonPropertyName("invite_id")]
    public string? InviteId { get; init; }

    [JsonPropertyName("allow_open_invite")]
    public bool AllowOpenInvite { get; init; }

    [JsonPropertyName("scheme_id")]
    public string? SchemeId { get; init; }

    [JsonPropertyName("group_constrained")]
    public bool? GroupConstrained { get; init; }

    [JsonPropertyName("company_name")]
    public string? CompanyName { get; init; }

    [JsonPropertyName("last_team_icon_update")]
    public long LastTeamIconUpdate { get; init; }

    [JsonPropertyName("policy_id")]
    public string? PolicyId { get; init; }
}
