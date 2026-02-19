using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Teams;

/// <summary>
/// Represents statistics for a team.
/// </summary>
public record TeamStats
{
    [JsonPropertyName("team_id")]
    public string TeamId { get; init; } = string.Empty;

    [JsonPropertyName("total_member_count")]
    public long TotalMemberCount { get; init; }

    [JsonPropertyName("active_member_count")]
    public long ActiveMemberCount { get; init; }
}
