using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Groups;

/// <summary>
/// Represents statistics for a group.
/// </summary>
public record GroupStats
{
    [JsonPropertyName("group_id")]
    public string GroupId { get; init; } = string.Empty;

    [JsonPropertyName("total_member_count")]
    public long TotalMemberCount { get; init; }
}
