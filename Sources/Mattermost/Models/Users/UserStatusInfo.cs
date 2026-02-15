using System.Text.Json.Serialization;
using Mattermost.Models.Enums;

namespace Mattermost.Models.Users
{
    /// <summary>
    /// User presence/status from the API (e.g. users/status/ids).
    /// </summary>
    public class UserStatusInfo
    {
        [JsonPropertyName("user_id")]
        public string UserId { get; set; } = string.Empty;

        [JsonPropertyName("status")]
        public string StatusText { get; set; } = string.Empty;

        [JsonIgnore]
        public UserStatus Status => StatusText?.ToLowerInvariant() switch
        {
            "online" => UserStatus.Online,
            "offline" => UserStatus.Offline,
            "away" => UserStatus.Away,
            "dnd" => UserStatus.DoNotDisturb,
            _ => UserStatus.Unknown,
        };
    }
}
