namespace Mattermost.Models.Channels
{
    /// <summary>
    /// Info for a direct message channel (for listing DMs with optional last message preview).
    /// </summary>
    public class DirectChannelInfo
    {
        public string ChannelId { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public long LastPostAt { get; set; }
        public string? LastMessagePreview { get; set; }
    }
}
