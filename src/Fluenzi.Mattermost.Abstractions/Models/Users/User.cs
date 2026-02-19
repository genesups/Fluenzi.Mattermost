using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Users;

/// <summary>
/// Represents a Mattermost user profile.
/// </summary>
public record User
{
    [JsonPropertyName("id")]
    public string Id { get; init; } = string.Empty;

    [JsonPropertyName("create_at")]
    public long CreateAt { get; init; }

    [JsonPropertyName("update_at")]
    public long UpdateAt { get; init; }

    [JsonPropertyName("delete_at")]
    public long DeleteAt { get; init; }

    [JsonPropertyName("username")]
    public string Username { get; init; } = string.Empty;

    [JsonPropertyName("auth_data")]
    public string? AuthData { get; init; }

    [JsonPropertyName("auth_service")]
    public string? AuthService { get; init; }

    [JsonPropertyName("email")]
    public string Email { get; init; } = string.Empty;

    [JsonPropertyName("nickname")]
    public string? Nickname { get; init; }

    [JsonPropertyName("first_name")]
    public string? FirstName { get; init; }

    [JsonPropertyName("last_name")]
    public string? LastName { get; init; }

    [JsonPropertyName("position")]
    public string? Position { get; init; }

    [JsonPropertyName("roles")]
    public string Roles { get; init; } = string.Empty;

    [JsonPropertyName("notify_props")]
    public UserNotifyProps? NotifyProps { get; init; }

    [JsonPropertyName("last_password_update")]
    public long LastPasswordUpdate { get; init; }

    [JsonPropertyName("last_picture_update")]
    public long LastPictureUpdate { get; init; }

    [JsonPropertyName("locale")]
    public string? Locale { get; init; }

    [JsonPropertyName("timezone")]
    public UserTimezone? Timezone { get; init; }

    [JsonPropertyName("props")]
    public Dictionary<string, string>? Props { get; init; }

    [JsonPropertyName("terms_of_service_id")]
    public string? TermsOfServiceId { get; init; }

    [JsonPropertyName("terms_of_service_create_at")]
    public long TermsOfServiceCreateAt { get; init; }

    [JsonPropertyName("remote_id")]
    public string? RemoteId { get; init; }

    [JsonPropertyName("bot_description")]
    public string? BotDescription { get; init; }

    [JsonPropertyName("bot_last_icon_update")]
    public long BotLastIconUpdate { get; init; }

    [JsonPropertyName("is_bot")]
    public bool IsBot { get; init; }

    [JsonPropertyName("last_activity_at")]
    public long LastActivityAt { get; init; }

    [JsonPropertyName("mfa_active")]
    public bool MfaActive { get; init; }

    [JsonPropertyName("allow_marketing")]
    public bool AllowMarketing { get; init; }
}
