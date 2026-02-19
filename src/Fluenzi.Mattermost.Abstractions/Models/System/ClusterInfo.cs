using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.System;

public record ClusterInfo
{
    [JsonPropertyName("id")] public string Id { get; init; } = "";
    [JsonPropertyName("version")] public string Version { get; init; } = "";
    [JsonPropertyName("config_hash")] public string ConfigHash { get; init; } = "";
    [JsonPropertyName("ipaddress")] public string IpAddress { get; init; } = "";
    [JsonPropertyName("hostname")] public string Hostname { get; init; } = "";
    [JsonPropertyName("is_alive")] public bool IsAlive { get; init; }
    [JsonPropertyName("last_ping")] public long LastPing { get; init; }
    [JsonPropertyName("schema_version")] public string SchemaVersion { get; init; } = "";
}
