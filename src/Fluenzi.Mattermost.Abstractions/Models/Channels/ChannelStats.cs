using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Channels;

/// <summary>
/// Represents statistics for a channel.
/// </summary>
public record ChannelStats
{
    [JsonPropertyName("channel_id")]
    public string ChannelId { get; init; } = string.Empty;

    [JsonPropertyName("member_count")]
    public long MemberCount { get; init; }

    [JsonPropertyName("guest_count")]
    public long GuestCount { get; init; }

    [JsonPropertyName("pinned_post_count")]
    public long PinnedPostCount { get; init; }

    [JsonPropertyName("files_count")]
    public long FilesCount { get; init; }
}
