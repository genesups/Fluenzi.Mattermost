using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Channels;

/// <summary>
/// Represents a Mattermost channel.
/// </summary>
public record Channel
{
    [JsonPropertyName("id")]
    public string Id { get; init; } = string.Empty;

    [JsonPropertyName("create_at")]
    public long CreateAt { get; init; }

    [JsonPropertyName("update_at")]
    public long UpdateAt { get; init; }

    [JsonPropertyName("delete_at")]
    public long DeleteAt { get; init; }

    [JsonPropertyName("team_id")]
    public string? TeamId { get; init; }

    [JsonPropertyName("type")]
    public string Type { get; init; } = string.Empty;

    [JsonPropertyName("display_name")]
    public string DisplayName { get; init; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    [JsonPropertyName("header")]
    public string? Header { get; init; }

    [JsonPropertyName("purpose")]
    public string? Purpose { get; init; }

    [JsonPropertyName("last_post_at")]
    public long LastPostAt { get; init; }

    [JsonPropertyName("total_msg_count")]
    public long TotalMessageCount { get; init; }

    [JsonPropertyName("creator_id")]
    public string? CreatorId { get; init; }

    [JsonPropertyName("scheme_id")]
    public string? SchemeId { get; init; }

    [JsonPropertyName("last_root_post_at")]
    public long LastRootPostAt { get; init; }

    [JsonPropertyName("group_constrained")]
    public bool? GroupConstrained { get; init; }

    [JsonPropertyName("shared")]
    public bool? Shared { get; init; }

    [JsonPropertyName("policy_id")]
    public string? PolicyId { get; init; }

    [JsonPropertyName("props")]
    public Dictionary<string, object>? Props { get; init; }

    [JsonPropertyName("teammate_id")]
    public string? TeammateId { get; init; }

    [JsonPropertyName("status")]
    public string? Status { get; init; }
}
