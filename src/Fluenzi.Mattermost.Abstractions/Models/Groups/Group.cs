using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Groups;

/// <summary>
/// Represents a Mattermost group (LDAP/custom).
/// </summary>
public record Group
{
    [JsonPropertyName("id")]
    public string Id { get; init; } = string.Empty;

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("display_name")]
    public string DisplayName { get; init; } = string.Empty;

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("source")]
    public string? Source { get; init; }

    [JsonPropertyName("remote_id")]
    public string? RemoteId { get; init; }

    [JsonPropertyName("create_at")]
    public long CreateAt { get; init; }

    [JsonPropertyName("update_at")]
    public long UpdateAt { get; init; }

    [JsonPropertyName("delete_at")]
    public long DeleteAt { get; init; }

    [JsonPropertyName("has_syncables")]
    public bool HasSyncables { get; init; }

    [JsonPropertyName("member_count")]
    public long MemberCount { get; init; }

    [JsonPropertyName("allow_reference")]
    public bool AllowReference { get; init; }

    [JsonPropertyName("scheme_admin")]
    public bool SchemeAdmin { get; init; }
}
