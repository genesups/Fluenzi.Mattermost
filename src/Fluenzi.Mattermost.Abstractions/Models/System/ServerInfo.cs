using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.System;

/// <summary>
/// Represents basic server version and build information.
/// </summary>
public record ServerInfo
{
    [JsonPropertyName("Version")]
    public string? Version { get; init; }

    [JsonPropertyName("BuildNumber")]
    public string? BuildNumber { get; init; }

    [JsonPropertyName("BuildDate")]
    public string? BuildDate { get; init; }

    [JsonPropertyName("BuildHash")]
    public string? BuildHash { get; init; }

    [JsonPropertyName("BuildHashEnterprise")]
    public string? BuildHashEnterprise { get; init; }

    [JsonPropertyName("Edition")]
    public string? Edition { get; init; }

    [JsonPropertyName("Configuration")]
    public Dictionary<string, object>? Configuration { get; init; }
}
