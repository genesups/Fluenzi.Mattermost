using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Mattermost.Models.Posts;
using Mattermost.Models.Responses;

namespace Mattermost
{
    /// <summary>
    /// Session for a single Mattermost channel: posts, members with presence, send message, and real-time events.
    /// All Mattermost API and WebSocket usage is encapsulated here.
    /// </summary>
    public interface IMattermostChannelSession : IDisposable
    {
        /// <summary>Channel identifier.</summary>
        string ChannelId { get; }

        /// <summary>Channel display name (from server).</summary>
        string ChannelDisplayName { get; }

        /// <summary>Whether the underlying client is connected via WebSocket.</summary>
        bool IsConnected { get; }

        /// <summary>Current authenticated user ID (set after ConnectAsync).</summary>
        string? CurrentUserId { get; }

        /// <summary>Raised when a new post is received for this channel (real-time).</summary>
        event EventHandler<Post>? NewPostInChannel;

        /// <summary>Raised when a user's presence status changes (for users in this channel).</summary>
        event EventHandler<(string UserId, string Status)>? UserStatusChanged;

        /// <summary>Connect and start receiving real-time updates. Call once after creation.</summary>
        Task ConnectAsync(CancellationToken cancellationToken = default);

        /// <summary>Disconnect and stop receiving. Safe to call multiple times.</summary>
        Task DisconnectAsync();

        /// <summary>Get a page of posts (newest first by default). Use <paramref name="beforePostId"/> for older posts.</summary>
        Task<ChannelPostsResponse> GetPostsPageAsync(string? beforePostId = null, string? afterPostId = null, int perPage = 60, CancellationToken cancellationToken = default);

        /// <summary>Send a message to the channel.</summary>
        Task<Post> SendMessageAsync(string message, CancellationToken cancellationToken = default);

        /// <summary>Get channel members with display names and current presence status.</summary>
        Task<IReadOnlyList<ChannelMemberWithStatus>> GetChannelMembersWithStatusAsync(CancellationToken cancellationToken = default);
    }
}
