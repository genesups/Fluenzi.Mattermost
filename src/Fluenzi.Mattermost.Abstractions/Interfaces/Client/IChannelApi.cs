using Fluenzi.Mattermost.Models.Channels;
using Fluenzi.Mattermost.Models.Posts;
using Fluenzi.Mattermost.Models.Common;

namespace Fluenzi.Mattermost.Interfaces.Client;

public interface IChannelApi
{
    Task<Channel> GetChannelAsync(string channelId, CancellationToken ct = default);
    Task<Channel> GetChannelByNameAsync(string teamId, string channelName, bool includeDeleted = false, CancellationToken ct = default);
    Task<IReadOnlyList<Channel>> GetChannelsForUserAsync(string userId, string teamId, int page = 0, int perPage = 200, CancellationToken ct = default);
    Task<IReadOnlyList<Channel>> GetPublicChannelsForTeamAsync(string teamId, int page = 0, int perPage = 200, CancellationToken ct = default);
    Task<IReadOnlyList<Channel>> GetPrivateChannelsForTeamAsync(string teamId, int page = 0, int perPage = 200, CancellationToken ct = default);
    Task<IReadOnlyList<Channel>> SearchChannelsAsync(string teamId, string term, CancellationToken ct = default);
    Task<Channel> CreateChannelAsync(Channel channel, CancellationToken ct = default);
    Task<Channel> UpdateChannelAsync(string channelId, Channel channel, CancellationToken ct = default);
    Task<Channel> PatchChannelAsync(string channelId, Dictionary<string, object> patch, CancellationToken ct = default);
    Task DeleteChannelAsync(string channelId, CancellationToken ct = default);
    Task RestoreChannelAsync(string channelId, CancellationToken ct = default);
    Task<Channel> CreateDirectChannelAsync(string userId1, string userId2, CancellationToken ct = default);
    Task<Channel> CreateGroupChannelAsync(IEnumerable<string> userIds, CancellationToken ct = default);
    Task<ChannelMember> AddChannelMemberAsync(string channelId, string userId, CancellationToken ct = default);
    Task RemoveChannelMemberAsync(string channelId, string userId, CancellationToken ct = default);
    Task<PagedResult<ChannelMember>> GetChannelMembersAsync(string channelId, int page = 0, int perPage = 60, CancellationToken ct = default);
    Task<ChannelMember> GetChannelMemberAsync(string channelId, string userId, CancellationToken ct = default);
    Task<IReadOnlyList<ChannelMember>> GetChannelMembersForUserAsync(string userId, string teamId, CancellationToken ct = default);
    Task<ChannelStats> GetChannelStatsAsync(string channelId, CancellationToken ct = default);
    Task<IReadOnlyList<Post>> GetPinnedPostsAsync(string channelId, CancellationToken ct = default);
    Task UpdateChannelMemberNotifyPropsAsync(string channelId, string userId, ChannelNotifyProps props, CancellationToken ct = default);
    Task UpdateChannelMemberRolesAsync(string channelId, string userId, string roles, CancellationToken ct = default);
    Task ViewChannelAsync(string userId, string channelId, string? prevChannelId = null, CancellationToken ct = default);
    Task<IReadOnlyList<ChannelCategory>> GetSidebarCategoriesAsync(string userId, string teamId, CancellationToken ct = default);
    Task<ChannelCategory> UpdateSidebarCategoryAsync(string userId, string teamId, string categoryId, ChannelCategory category, CancellationToken ct = default);
}
