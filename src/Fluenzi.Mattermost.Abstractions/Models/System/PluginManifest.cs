using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.System;

/// <summary>
/// Represents a plugin's manifest metadata.
/// </summary>
public record PluginManifest
{
    [JsonPropertyName("id")]
    public string Id { get; init; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("homepage_url")]
    public string? HomepageUrl { get; init; }

    [JsonPropertyName("support_url")]
    public string? SupportUrl { get; init; }

    [JsonPropertyName("release_notes_url")]
    public string? ReleaseNotesUrl { get; init; }

    [JsonPropertyName("icon_path")]
    public string? IconPath { get; init; }

    [JsonPropertyName("version")]
    public string? Version { get; init; }

    [JsonPropertyName("min_server_version")]
    public string? MinServerVersion { get; init; }

    [JsonPropertyName("server_executables")]
    public Dictionary<string, string>? ServerExecutables { get; init; }

    [JsonPropertyName("webapp_bundle_path")]
    public string? WebappBundlePath { get; init; }

    [JsonPropertyName("settings_schema")]
    public object? SettingsSchema { get; init; }
}
