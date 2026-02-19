using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Channels;

/// <summary>
/// Represents channel-level notification preferences for a member.
/// </summary>
public record ChannelNotifyProps
{
    [JsonPropertyName("desktop")]
    public string? Desktop { get; init; }

    [JsonPropertyName("email")]
    public string? Email { get; init; }

    [JsonPropertyName("ignore_channel_mentions")]
    public string? IgnoreChannelMentions { get; init; }

    [JsonPropertyName("mark_unread")]
    public string? MarkUnread { get; init; }

    [JsonPropertyName("push")]
    public string? Push { get; init; }

    [JsonPropertyName("desktop_threads")]
    public string? DesktopThreads { get; init; }

    [JsonPropertyName("push_threads")]
    public string? PushThreads { get; init; }

    [JsonPropertyName("email_threads")]
    public string? EmailThreads { get; init; }
}
