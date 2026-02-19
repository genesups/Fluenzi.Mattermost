using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Posts;

/// <summary>
/// Represents an ordered list of posts, typically returned by search or channel endpoints.
/// </summary>
public record PostList
{
    [JsonPropertyName("order")]
    public string[] Order { get; init; } = [];

    [JsonPropertyName("posts")]
    public Dictionary<string, Post> Posts { get; init; } = new();

    [JsonPropertyName("next_post_id")]
    public string? NextPostId { get; init; }

    [JsonPropertyName("prev_post_id")]
    public string? PrevPostId { get; init; }

    [JsonPropertyName("has_next")]
    public bool HasNext { get; init; }

    [JsonPropertyName("first_inaccessible_post_time")]
    public long FirstInaccessiblePostTime { get; init; }
}
