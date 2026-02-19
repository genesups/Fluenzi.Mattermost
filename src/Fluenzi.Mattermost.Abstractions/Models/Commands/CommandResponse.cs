using System.Text.Json.Serialization;
using Fluenzi.Mattermost.Models.Posts;

namespace Fluenzi.Mattermost.Models.Commands;

/// <summary>
/// Represents the response from executing a slash command.
/// </summary>
public record CommandResponse
{
    [JsonPropertyName("response_type")]
    public string? ResponseType { get; init; }

    [JsonPropertyName("text")]
    public string? Text { get; init; }

    [JsonPropertyName("username")]
    public string? Username { get; init; }

    [JsonPropertyName("channel_id")]
    public string? ChannelId { get; init; }

    [JsonPropertyName("icon_url")]
    public string? IconUrl { get; init; }

    [JsonPropertyName("goto_location")]
    public string? GotoLocation { get; init; }

    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("props")]
    public Dictionary<string, object>? Props { get; init; }

    [JsonPropertyName("attachments")]
    public PostAttachment[]? Attachments { get; init; }
}
