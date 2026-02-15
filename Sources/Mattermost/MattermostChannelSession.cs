using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Mattermost.Events;
using Mattermost.Models.Channels;
using Mattermost.Models.Posts;
using Mattermost.Models.Responses;
using Mattermost.Models.Users;

namespace Mattermost
{
    /// <summary>
    /// Session for a single Mattermost channel: encapsulates client, filters events by channel, exposes posts and members with presence.
    /// </summary>
    public sealed class MattermostChannelSession : IMattermostChannelSession
    {
        private readonly string _serverUrl;
        private readonly string _accessToken;
        private MattermostClient? _client;
        private readonly object _lock = new object();
        private HashSet<string>? _channelMemberIds;
        private bool _disposed;

        public string ChannelId { get; }
        public string ChannelDisplayName { get; private set; } = string.Empty;
        public bool IsConnected => _client?.IsConnected ?? false;
        public string? CurrentUserId { get; private set; }

        public event EventHandler<Post>? NewPostInChannel;
        public event EventHandler<(string UserId, string Status)>? UserStatusChanged;

        public MattermostChannelSession(string serverUrl, string accessToken, string channelId)
        {
            _serverUrl = serverUrl?.TrimEnd('/') ?? throw new ArgumentNullException(nameof(serverUrl));
            _accessToken = accessToken ?? throw new ArgumentNullException(nameof(accessToken));
            ChannelId = channelId ?? throw new ArgumentNullException(nameof(channelId));
        }

        public async Task ConnectAsync(CancellationToken cancellationToken = default)
        {
            if (_client != null)
                return;

            var uri = new Uri(_serverUrl.StartsWith("http") ? _serverUrl : "https://" + _serverUrl);
            var client = new MattermostClient(uri, _accessToken);
            var me = await client.GetMeAsync();
            CurrentUserId = me?.Id;
            var channel = await client.GetChannelAsync(ChannelId);
            ChannelDisplayName = channel.DisplayName ?? channel.Name ?? ChannelId;

            var members = await client.GetChannelMembersAsync(ChannelId);
            lock (_lock)
            {
                _channelMemberIds = new HashSet<string>(members.Select(m => m.UserId), StringComparer.Ordinal);
            }

            client.OnMessageReceived += OnClientMessageReceived;
            client.OnStatusUpdated += OnClientStatusUpdated;
            _client = client;
            await _client.StartReceivingAsync(cancellationToken);
        }

        public async Task DisconnectAsync()
        {
            var client = _client;
            _client = null;
            if (client == null)
                return;
            try
            {
                client.OnMessageReceived -= OnClientMessageReceived;
                client.OnStatusUpdated -= OnClientStatusUpdated;
                await client.StopReceivingAsync();
            }
            finally
            {
                client.Dispose();
            }
        }

        public Task<ChannelPostsResponse> GetPostsPageAsync(string? beforePostId = null, string? afterPostId = null, int perPage = 60, CancellationToken cancellationToken = default)
        {
            if (_client == null)
                throw new InvalidOperationException("Not connected. Call ConnectAsync first.");
            return _client.GetChannelPostsAsync(ChannelId, page: 0, perPage, beforePostId, afterPostId);
        }

        public Task<Post> SendMessageAsync(string message, CancellationToken cancellationToken = default)
        {
            if (_client == null)
                throw new InvalidOperationException("Not connected. Call ConnectAsync first.");
            return _client.CreatePostAsync(ChannelId, message);
        }

        public async Task<IReadOnlyList<ChannelMemberWithStatus>> GetChannelMembersWithStatusAsync(CancellationToken cancellationToken = default)
        {
            if (_client == null)
                throw new InvalidOperationException("Not connected. Call ConnectAsync first.");

            var members = await _client.GetChannelMembersAsync(ChannelId);
            var userIds = members.Select(m => m.UserId).Distinct().ToList();
            if (userIds.Count == 0)
                return Array.Empty<ChannelMemberWithStatus>();

            var userTasks = userIds.Select(id => _client.GetUserAsync(id));
            var users = await Task.WhenAll(userTasks);
            var statusList = await _client.GetUsersStatusByIdsAsync(userIds);
            var statusMap = statusList.ToDictionary(s => s.UserId, s => s.StatusText, StringComparer.Ordinal);

            return users
                .Select(u => new ChannelMemberWithStatus
                {
                    UserId = u.Id,
                    DisplayName = string.IsNullOrEmpty(u.Nickname) ? (u.Username ?? u.Id) : u.Nickname,
                    Status = statusMap.TryGetValue(u.Id, out var status) ? status : "offline"
                })
                .ToList();
        }

        private void OnClientMessageReceived(object? sender, MessageEventArgs e)
        {
            if (e.Message?.Post == null)
                return;
            if (string.Equals(e.Message.Post.ChannelId, ChannelId, StringComparison.Ordinal))
                NewPostInChannel?.Invoke(this, e.Message.Post);
        }

        private void OnClientStatusUpdated(object? sender, UserStatusChangeEventArgs e)
        {
            bool inChannel;
            lock (_lock)
            {
                inChannel = _channelMemberIds != null && _channelMemberIds.Contains(e.UserStatusUpdate.UserId);
            }
            if (inChannel)
                UserStatusChanged?.Invoke(this, (e.UserStatusUpdate.UserId, e.UserStatusUpdate.StatusText));
        }

        public void Dispose()
        {
            if (_disposed)
                return;
            _ = DisconnectAsync();
            _disposed = true;
            GC.SuppressFinalize(this);
        }
    }
}
