using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.System;

/// <summary>
/// Represents the server's license information.
/// </summary>
public record ServerLicense
{
    [JsonPropertyName("id")]
    public string Id { get; init; } = string.Empty;

    [JsonPropertyName("issued_at")]
    public long IssuedAt { get; init; }

    [JsonPropertyName("starts_at")]
    public long StartsAt { get; init; }

    [JsonPropertyName("expires_at")]
    public long ExpiresAt { get; init; }

    [JsonPropertyName("customer")]
    public Dictionary<string, object>? Customer { get; init; }

    [JsonPropertyName("features")]
    public Dictionary<string, object>? Features { get; init; }

    [JsonPropertyName("sku_name")]
    public string? SkuName { get; init; }

    [JsonPropertyName("sku_short_name")]
    public string? SkuShortName { get; init; }

    [JsonPropertyName("is_trial")]
    public bool IsTrial { get; init; }

    [JsonPropertyName("is_gov_sku")]
    public bool IsGovSku { get; init; }
}
