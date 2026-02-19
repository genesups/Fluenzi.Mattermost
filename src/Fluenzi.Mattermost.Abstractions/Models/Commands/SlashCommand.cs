using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Commands;

/// <summary>
/// Represents a custom slash command.
/// </summary>
public record SlashCommand
{
    [JsonPropertyName("id")]
    public string Id { get; init; } = string.Empty;

    [JsonPropertyName("token")]
    public string? Token { get; init; }

    [JsonPropertyName("create_at")]
    public long CreateAt { get; init; }

    [JsonPropertyName("update_at")]
    public long UpdateAt { get; init; }

    [JsonPropertyName("delete_at")]
    public long DeleteAt { get; init; }

    [JsonPropertyName("creator_id")]
    public string CreatorId { get; init; } = string.Empty;

    [JsonPropertyName("team_id")]
    public string TeamId { get; init; } = string.Empty;

    [JsonPropertyName("trigger")]
    public string Trigger { get; init; } = string.Empty;

    [JsonPropertyName("method")]
    public string? Method { get; init; }

    [JsonPropertyName("username")]
    public string? Username { get; init; }

    [JsonPropertyName("icon_url")]
    public string? IconUrl { get; init; }

    [JsonPropertyName("auto_complete")]
    public bool AutoComplete { get; init; }

    [JsonPropertyName("auto_complete_desc")]
    public string? AutoCompleteDesc { get; init; }

    [JsonPropertyName("auto_complete_hint")]
    public string? AutoCompleteHint { get; init; }

    [JsonPropertyName("display_name")]
    public string? DisplayName { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("url")]
    public string? Url { get; init; }

    [JsonPropertyName("autocomplete_data")]
    public object? AutocompleteData { get; init; }
}
