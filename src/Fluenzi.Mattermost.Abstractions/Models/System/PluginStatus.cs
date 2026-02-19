using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.System;

/// <summary>
/// Represents the runtime status of a plugin.
/// </summary>
public record PluginStatus
{
    [JsonPropertyName("plugin_id")]
    public string PluginId { get; init; } = string.Empty;

    [JsonPropertyName("cluster_id")]
    public string? ClusterId { get; init; }

    [JsonPropertyName("plugin_path")]
    public string? PluginPath { get; init; }

    [JsonPropertyName("state")]
    public int State { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("version")]
    public string? Version { get; init; }
}
