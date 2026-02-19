using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Channels;

/// <summary>
/// Represents a sidebar channel category.
/// </summary>
public record ChannelCategory
{
    [JsonPropertyName("id")]
    public string Id { get; init; } = string.Empty;

    [JsonPropertyName("user_id")]
    public string UserId { get; init; } = string.Empty;

    [JsonPropertyName("team_id")]
    public string TeamId { get; init; } = string.Empty;

    [JsonPropertyName("display_name")]
    public string DisplayName { get; init; } = string.Empty;

    [JsonPropertyName("type")]
    public string Type { get; init; } = string.Empty;

    [JsonPropertyName("sorting")]
    public string? Sorting { get; init; }

    [JsonPropertyName("channel_ids")]
    public string[]? ChannelIds { get; init; }

    [JsonPropertyName("muted")]
    public bool Muted { get; init; }

    [JsonPropertyName("collapsed")]
    public bool Collapsed { get; init; }
}
