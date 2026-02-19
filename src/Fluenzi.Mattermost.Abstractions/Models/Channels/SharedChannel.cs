using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Channels;

public record SharedChannel
{
    [JsonPropertyName("id")] public string Id { get; init; } = "";
    [JsonPropertyName("team_id")] public string TeamId { get; init; } = "";
    [JsonPropertyName("home")] public bool Home { get; init; }
    [JsonPropertyName("readonly")] public bool ReadOnly { get; init; }
    [JsonPropertyName("share_name")] public string ShareName { get; init; } = "";
    [JsonPropertyName("share_display_name")] public string ShareDisplayName { get; init; } = "";
    [JsonPropertyName("share_purpose")] public string SharePurpose { get; init; } = "";
    [JsonPropertyName("share_header")] public string ShareHeader { get; init; } = "";
    [JsonPropertyName("creator_id")] public string CreatorId { get; init; } = "";
    [JsonPropertyName("create_at")] public long CreateAt { get; init; }
    [JsonPropertyName("update_at")] public long UpdateAt { get; init; }
    [JsonPropertyName("remote_id")] public string RemoteId { get; init; } = "";
}

public record SharedChannelRemote
{
    [JsonPropertyName("id")] public string Id { get; init; } = "";
    [JsonPropertyName("channel_id")] public string ChannelId { get; init; } = "";
    [JsonPropertyName("creator_id")] public string CreatorId { get; init; } = "";
    [JsonPropertyName("create_at")] public long CreateAt { get; init; }
    [JsonPropertyName("update_at")] public long UpdateAt { get; init; }
    [JsonPropertyName("is_invite_accepted")] public bool IsInviteAccepted { get; init; }
    [JsonPropertyName("is_invite_confirmed")] public bool IsInviteConfirmed { get; init; }
    [JsonPropertyName("remote_id")] public string RemoteId { get; init; } = "";
    [JsonPropertyName("last_post_update_at")] public long LastPostUpdateAt { get; init; }
    [JsonPropertyName("last_post_id")] public string LastPostId { get; init; } = "";
}
