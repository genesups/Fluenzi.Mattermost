using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Threads;

/// <summary>
/// Represents the response when fetching user threads.
/// </summary>
public record ThreadResponse
{
    [JsonPropertyName("threads")]
    public UserThread[]? Threads { get; init; }

    [JsonPropertyName("total_unread_threads")]
    public long TotalUnreadThreads { get; init; }

    [JsonPropertyName("total_unread_mentions")]
    public long TotalUnreadMentions { get; init; }

    [JsonPropertyName("total")]
    public long TotalThreads { get; init; }

    [JsonPropertyName("has_next")]
    public bool HasNext { get; init; }
}
