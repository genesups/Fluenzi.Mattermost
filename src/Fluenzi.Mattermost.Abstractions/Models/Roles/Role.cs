using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Roles;

/// <summary>
/// Represents a Mattermost role with associated permissions.
/// </summary>
public record Role
{
    [JsonPropertyName("id")]
    public string Id { get; init; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    [JsonPropertyName("display_name")]
    public string? DisplayName { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("permissions")]
    public string[]? Permissions { get; init; }

    [JsonPropertyName("scheme_managed")]
    public bool SchemeManaged { get; init; }

    [JsonPropertyName("create_at")]
    public long CreateAt { get; init; }

    [JsonPropertyName("update_at")]
    public long UpdateAt { get; init; }

    [JsonPropertyName("delete_at")]
    public long DeleteAt { get; init; }

    [JsonPropertyName("built_in")]
    public bool BuiltIn { get; init; }
}
