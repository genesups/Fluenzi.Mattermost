using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.System;

public record OutgoingOAuthConnection
{
    [JsonPropertyName("id")] public string Id { get; init; } = "";
    [JsonPropertyName("name")] public string Name { get; init; } = "";
    [JsonPropertyName("creator_id")] public string CreatorId { get; init; } = "";
    [JsonPropertyName("create_at")] public long CreateAt { get; init; }
    [JsonPropertyName("update_at")] public long UpdateAt { get; init; }
    [JsonPropertyName("client_id")] public string ClientId { get; init; } = "";
    [JsonPropertyName("client_secret")] public string ClientSecret { get; init; } = "";
    [JsonPropertyName("credentials_username")] public string CredentialsUsername { get; init; } = "";
    [JsonPropertyName("credentials_password")] public string CredentialsPassword { get; init; } = "";
    [JsonPropertyName("oauth_token_url")] public string OAuthTokenUrl { get; init; } = "";
    [JsonPropertyName("grant_type")] public string GrantType { get; init; } = ""; // "client_credentials", "password"
    [JsonPropertyName("audiences")] public IReadOnlyList<string> Audiences { get; init; } = [];
}
