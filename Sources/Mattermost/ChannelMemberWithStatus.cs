namespace Mattermost
{
    /// <summary>
    /// Channel member with display name, presence status, and profile details for use in channel session UI.
    /// </summary>
    public sealed class ChannelMemberWithStatus
    {
        /// <summary>User identifier.</summary>
        public string UserId { get; set; } = string.Empty;

        /// <summary>Display name (nickname or username).</summary>
        public string DisplayName { get; set; } = string.Empty;

        /// <summary>Full name (first + last).</summary>
        public string FullName { get; set; } = string.Empty;

        /// <summary>Email address.</summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>Channel/team roles (e.g. "channel_admin system_user").</summary>
        public string Roles { get; set; } = string.Empty;

        /// <summary>Presence status: online, away, offline, dnd.</summary>
        public string Status { get; set; } = "offline";
    }
}
