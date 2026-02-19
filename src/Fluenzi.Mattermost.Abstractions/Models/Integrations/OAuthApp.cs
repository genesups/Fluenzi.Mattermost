using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Integrations;

/// <summary>
/// Represents an OAuth 2.0 application.
/// </summary>
public record OAuthApp
{
    [JsonPropertyName("id")]
    public string Id { get; init; } = string.Empty;

    [JsonPropertyName("creator_id")]
    public string CreatorId { get; init; } = string.Empty;

    [JsonPropertyName("create_at")]
    public long CreateAt { get; init; }

    [JsonPropertyName("update_at")]
    public long UpdateAt { get; init; }

    [JsonPropertyName("client_secret")]
    public string? ClientSecret { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("icon_url")]
    public string? IconUrl { get; init; }

    [JsonPropertyName("callback_urls")]
    public string[]? CallbackUrls { get; init; }

    [JsonPropertyName("homepage")]
    public string? Homepage { get; init; }

    [JsonPropertyName("is_trusted")]
    public bool IsTrusted { get; init; }
}
