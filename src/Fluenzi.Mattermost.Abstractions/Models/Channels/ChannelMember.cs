using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Channels;

/// <summary>
/// Represents a user's membership in a channel.
/// </summary>
public record ChannelMember
{
    [JsonPropertyName("channel_id")]
    public string ChannelId { get; init; } = string.Empty;

    [JsonPropertyName("user_id")]
    public string UserId { get; init; } = string.Empty;

    [JsonPropertyName("roles")]
    public string? Roles { get; init; }

    [JsonPropertyName("last_viewed_at")]
    public long LastViewedAt { get; init; }

    [JsonPropertyName("msg_count")]
    public long MsgCount { get; init; }

    [JsonPropertyName("mention_count")]
    public long MentionCount { get; init; }

    [JsonPropertyName("mention_count_root")]
    public long MentionCountRoot { get; init; }

    [JsonPropertyName("msg_count_root")]
    public long MsgCountRoot { get; init; }

    [JsonPropertyName("notify_props")]
    public ChannelNotifyProps? NotifyProps { get; init; }

    [JsonPropertyName("last_update_at")]
    public long LastUpdateAt { get; init; }

    [JsonPropertyName("scheme_user")]
    public bool SchemeUser { get; init; }

    [JsonPropertyName("scheme_admin")]
    public bool SchemeAdmin { get; init; }

    [JsonPropertyName("scheme_guest")]
    public bool SchemeGuest { get; init; }

    [JsonPropertyName("explicit_roles")]
    public string? ExplicitRoles { get; init; }

    [JsonPropertyName("urgent_mention_count")]
    public long UrgentMentionCount { get; init; }
}
