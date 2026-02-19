using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.System;

public record Scheme
{
    [JsonPropertyName("id")] public string Id { get; init; } = "";
    [JsonPropertyName("name")] public string Name { get; init; } = "";
    [JsonPropertyName("display_name")] public string DisplayName { get; init; } = "";
    [JsonPropertyName("description")] public string Description { get; init; } = "";
    [JsonPropertyName("scope")] public string Scope { get; init; } = ""; // "team", "channel"
    [JsonPropertyName("default_team_admin_role")] public string DefaultTeamAdminRole { get; init; } = "";
    [JsonPropertyName("default_team_user_role")] public string DefaultTeamUserRole { get; init; } = "";
    [JsonPropertyName("default_channel_admin_role")] public string DefaultChannelAdminRole { get; init; } = "";
    [JsonPropertyName("default_channel_user_role")] public string DefaultChannelUserRole { get; init; } = "";
    [JsonPropertyName("create_at")] public long CreateAt { get; init; }
    [JsonPropertyName("update_at")] public long UpdateAt { get; init; }
    [JsonPropertyName("delete_at")] public long DeleteAt { get; init; }
}
