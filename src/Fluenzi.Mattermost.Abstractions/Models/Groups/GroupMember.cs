using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Groups;

/// <summary>
/// Represents a user's membership in a group.
/// </summary>
public record GroupMember
{
    [JsonPropertyName("group_id")]
    public string GroupId { get; init; } = string.Empty;

    [JsonPropertyName("user_id")]
    public string UserId { get; init; } = string.Empty;

    [JsonPropertyName("create_at")]
    public long CreateAt { get; init; }

    [JsonPropertyName("delete_at")]
    public long DeleteAt { get; init; }
}
