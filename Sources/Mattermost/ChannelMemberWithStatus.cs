namespace Mattermost
{
    /// <summary>
    /// Channel member with display name and presence status for use in channel session UI.
    /// </summary>
    public sealed class ChannelMemberWithStatus
    {
        /// <summary>User identifier.</summary>
        public string UserId { get; set; } = string.Empty;

        /// <summary>Display name (from User).</summary>
        public string DisplayName { get; set; } = string.Empty;

        /// <summary>Presence status: online, away, offline, dnd.</summary>
        public string Status { get; set; } = "offline";
    }
}
