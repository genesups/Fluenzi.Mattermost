using System.Text.Json.Serialization;
using Fluenzi.Mattermost.Models.Posts;

namespace Fluenzi.Mattermost.Models.Threads;

/// <summary>
/// Represents a thread that a user is following.
/// </summary>
public record UserThread
{
    [JsonPropertyName("id")]
    public string Id { get; init; } = string.Empty;

    [JsonPropertyName("reply_count")]
    public long ReplyCount { get; init; }

    [JsonPropertyName("last_reply_at")]
    public long LastReplyAt { get; init; }

    [JsonPropertyName("last_viewed_at")]
    public long LastViewedAt { get; init; }

    [JsonPropertyName("participants")]
    public UserThreadParticipant[]? Participants { get; init; }

    [JsonPropertyName("post")]
    public Post? Post { get; init; }

    [JsonPropertyName("unread_replies")]
    public long UnreadReplies { get; init; }

    [JsonPropertyName("unread_mentions")]
    public long UnreadMentions { get; init; }

    [JsonPropertyName("is_urgent")]
    public bool IsUrgent { get; init; }

    [JsonPropertyName("delete_at")]
    public long DeleteAt { get; init; }
}
