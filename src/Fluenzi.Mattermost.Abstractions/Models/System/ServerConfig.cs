using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.System;

/// <summary>
/// Represents the Mattermost server configuration.
/// Uses a flexible dictionary approach for each settings section to accommodate
/// varying server versions and configurations.
/// </summary>
public record ServerConfig
{
    [JsonPropertyName("ServiceSettings")]
    public Dictionary<string, object?>? ServiceSettings { get; init; }

    [JsonPropertyName("TeamSettings")]
    public Dictionary<string, object?>? TeamSettings { get; init; }

    [JsonPropertyName("SqlSettings")]
    public Dictionary<string, object?>? SqlSettings { get; init; }

    [JsonPropertyName("LogSettings")]
    public Dictionary<string, object?>? LogSettings { get; init; }

    [JsonPropertyName("EmailSettings")]
    public Dictionary<string, object?>? EmailSettings { get; init; }

    [JsonPropertyName("FileSettings")]
    public Dictionary<string, object?>? FileSettings { get; init; }

    [JsonPropertyName("PluginSettings")]
    public Dictionary<string, object?>? PluginSettings { get; init; }

    [JsonPropertyName("DisplaySettings")]
    public Dictionary<string, object?>? DisplaySettings { get; init; }

    [JsonPropertyName("PasswordSettings")]
    public Dictionary<string, object?>? PasswordSettings { get; init; }

    [JsonPropertyName("GitLabSettings")]
    public Dictionary<string, object?>? GitLabSettings { get; init; }

    [JsonPropertyName("LocalizationSettings")]
    public Dictionary<string, object?>? LocalizationSettings { get; init; }

    [JsonPropertyName("NativeAppSettings")]
    public Dictionary<string, object?>? NativeAppSettings { get; init; }

    [JsonPropertyName("RateLimitSettings")]
    public Dictionary<string, object?>? RateLimitSettings { get; init; }

    [JsonPropertyName("PrivacySettings")]
    public Dictionary<string, object?>? PrivacySettings { get; init; }

    [JsonPropertyName("SupportSettings")]
    public Dictionary<string, object?>? SupportSettings { get; init; }

    [JsonPropertyName("ComplianceSettings")]
    public Dictionary<string, object?>? ComplianceSettings { get; init; }

    [JsonPropertyName("LdapSettings")]
    public Dictionary<string, object?>? LdapSettings { get; init; }

    [JsonPropertyName("SamlSettings")]
    public Dictionary<string, object?>? SamlSettings { get; init; }

    [JsonPropertyName("ClusterSettings")]
    public Dictionary<string, object?>? ClusterSettings { get; init; }

    [JsonPropertyName("MetricsSettings")]
    public Dictionary<string, object?>? MetricsSettings { get; init; }

    [JsonPropertyName("AnnouncementSettings")]
    public Dictionary<string, object?>? AnnouncementSettings { get; init; }

    [JsonPropertyName("ThemeSettings")]
    public Dictionary<string, object?>? ThemeSettings { get; init; }

    [JsonPropertyName("ExperimentalSettings")]
    public Dictionary<string, object?>? ExperimentalSettings { get; init; }

    [JsonPropertyName("FeatureFlags")]
    public Dictionary<string, object?>? FeatureFlags { get; init; }
}
