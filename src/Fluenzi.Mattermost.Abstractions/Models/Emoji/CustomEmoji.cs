using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Emoji;

/// <summary>
/// Represents a custom emoji uploaded to the server.
/// </summary>
public record CustomEmoji
{
    [JsonPropertyName("id")]
    public string Id { get; init; } = string.Empty;

    [JsonPropertyName("creator_id")]
    public string CreatorId { get; init; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    [JsonPropertyName("create_at")]
    public long CreateAt { get; init; }

    [JsonPropertyName("update_at")]
    public long UpdateAt { get; init; }

    [JsonPropertyName("delete_at")]
    public long DeleteAt { get; init; }
}
