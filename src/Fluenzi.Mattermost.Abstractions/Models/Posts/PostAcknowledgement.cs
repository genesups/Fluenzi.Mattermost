using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Posts;

/// <summary>
/// Represents a user's acknowledgement of a post.
/// </summary>
public record PostAcknowledgement
{
    [JsonPropertyName("user_id")]
    public string UserId { get; init; } = string.Empty;

    [JsonPropertyName("post_id")]
    public string PostId { get; init; } = string.Empty;

    [JsonPropertyName("acknowledged_at")]
    public long AcknowledgedAt { get; init; }
}
