using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Webhooks;

/// <summary>
/// Represents an incoming webhook configuration.
/// </summary>
public record IncomingWebhook
{
    [JsonPropertyName("id")]
    public string Id { get; init; } = string.Empty;

    [JsonPropertyName("create_at")]
    public long CreateAt { get; init; }

    [JsonPropertyName("update_at")]
    public long UpdateAt { get; init; }

    [JsonPropertyName("delete_at")]
    public long DeleteAt { get; init; }

    [JsonPropertyName("user_id")]
    public string UserId { get; init; } = string.Empty;

    [JsonPropertyName("channel_id")]
    public string ChannelId { get; init; } = string.Empty;

    [JsonPropertyName("team_id")]
    public string TeamId { get; init; } = string.Empty;

    [JsonPropertyName("display_name")]
    public string? DisplayName { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("username")]
    public string? Username { get; init; }

    [JsonPropertyName("icon_url")]
    public string? IconUrl { get; init; }

    [JsonPropertyName("channel_locked")]
    public bool ChannelLocked { get; init; }
}
