using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Users;

/// <summary>
/// Represents a user's notification preferences.
/// </summary>
public record UserNotifyProps
{
    [JsonPropertyName("channel")]
    public string? Channel { get; init; }

    [JsonPropertyName("desktop")]
    public string? Desktop { get; init; }

    [JsonPropertyName("desktop_sound")]
    public string? DesktopSound { get; init; }

    [JsonPropertyName("email")]
    public string? Email { get; init; }

    [JsonPropertyName("first_name")]
    public string? FirstName { get; init; }

    [JsonPropertyName("mention_keys")]
    public string? MentionKeys { get; init; }

    [JsonPropertyName("push")]
    public string? Push { get; init; }

    [JsonPropertyName("desktop_notification_sound")]
    public string? DesktopNotificationSound { get; init; }

    [JsonPropertyName("desktop_threads")]
    public string? DesktopThreads { get; init; }

    [JsonPropertyName("push_threads")]
    public string? PushThreads { get; init; }

    [JsonPropertyName("email_threads")]
    public string? EmailThreads { get; init; }

    [JsonPropertyName("comments")]
    public string? Comments { get; init; }

    [JsonPropertyName("auto_responder_active")]
    public string? AutoResponderActive { get; init; }

    [JsonPropertyName("auto_responder_message")]
    public string? AutoResponderMessage { get; init; }

    [JsonPropertyName("calls_desktop_sound")]
    public string? CallsDesktopSound { get; init; }

    [JsonPropertyName("calls_mobile_sound")]
    public string? CallsMobileSound { get; init; }
}
