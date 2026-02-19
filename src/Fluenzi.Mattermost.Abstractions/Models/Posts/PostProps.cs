using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Posts;

/// <summary>
/// Typed representation of common post properties.
/// </summary>
public record PostProps
{
    [JsonPropertyName("attachments")]
    public PostAttachment[]? Attachments { get; init; }

    [JsonPropertyName("from_webhook")]
    public string? FromWebhook { get; init; }

    [JsonPropertyName("override_username")]
    public string? OverrideUsername { get; init; }

    [JsonPropertyName("override_icon_url")]
    public string? OverrideIconUrl { get; init; }

    [JsonPropertyName("from_bot")]
    public string? FromBot { get; init; }

    [JsonPropertyName("disable_group_highlight")]
    public string? DisableGroupHighlight { get; init; }
}
