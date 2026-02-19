using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Teams;

/// <summary>
/// Represents unread message counts for a team.
/// </summary>
public record TeamUnread
{
    [JsonPropertyName("team_id")]
    public string TeamId { get; init; } = string.Empty;

    [JsonPropertyName("msg_count")]
    public long MsgCount { get; init; }

    [JsonPropertyName("mention_count")]
    public long MentionCount { get; init; }

    [JsonPropertyName("msg_count_root")]
    public long MsgCountRoot { get; init; }

    [JsonPropertyName("mention_count_root")]
    public long MentionCountRoot { get; init; }
}
