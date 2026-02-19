using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Webhooks;

/// <summary>
/// Represents an outgoing webhook configuration.
/// </summary>
public record OutgoingWebhook
{
    [JsonPropertyName("id")]
    public string Id { get; init; } = string.Empty;

    [JsonPropertyName("create_at")]
    public long CreateAt { get; init; }

    [JsonPropertyName("update_at")]
    public long UpdateAt { get; init; }

    [JsonPropertyName("delete_at")]
    public long DeleteAt { get; init; }

    [JsonPropertyName("creator_id")]
    public string CreatorId { get; init; } = string.Empty;

    [JsonPropertyName("channel_id")]
    public string? ChannelId { get; init; }

    [JsonPropertyName("team_id")]
    public string TeamId { get; init; } = string.Empty;

    [JsonPropertyName("trigger_words")]
    public string[]? TriggerWords { get; init; }

    [JsonPropertyName("trigger_when")]
    public int TriggerWhen { get; init; }

    [JsonPropertyName("callback_urls")]
    public string[]? CallbackUrls { get; init; }

    [JsonPropertyName("display_name")]
    public string? DisplayName { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("content_type")]
    public string? ContentType { get; init; }

    [JsonPropertyName("username")]
    public string? Username { get; init; }

    [JsonPropertyName("icon_url")]
    public string? IconUrl { get; init; }

    [JsonPropertyName("token")]
    public string? Token { get; init; }
}
