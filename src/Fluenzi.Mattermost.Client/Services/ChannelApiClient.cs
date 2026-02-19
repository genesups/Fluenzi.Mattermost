using Fluenzi.Mattermost.Client.Internal;
using Fluenzi.Mattermost.Constants;
using Fluenzi.Mattermost.Interfaces.Client;
using Fluenzi.Mattermost.Models.Channels;
using Fluenzi.Mattermost.Models.Common;
using Fluenzi.Mattermost.Models.Posts;

namespace Fluenzi.Mattermost.Client.Services;

public class ChannelApiClient : IChannelApi
{
    private readonly ApiRequestHandler _api;

    public ChannelApiClient(ApiRequestHandler api) => _api = api;

    public Task<Channel> GetChannelAsync(string channelId, CancellationToken ct = default)
        => _api.GetAsync<Channel>(string.Format(ApiRoutes.Channel, channelId), ct);

    public Task<Channel> GetChannelByNameAsync(string teamId, string channelName, bool includeDeleted = false, CancellationToken ct = default)
    {
        var url = string.Format(ApiRoutes.ChannelByName, teamId, channelName);
        if (includeDeleted) url += "?include_deleted=true";
        return _api.GetAsync<Channel>(url, ct);
    }

    public Task<IReadOnlyList<Channel>> GetChannelsForUserAsync(string userId, string teamId, int page = 0, int perPage = 200, CancellationToken ct = default)
        => _api.GetAsync<IReadOnlyList<Channel>>($"{string.Format(ApiRoutes.UserChannels, userId, teamId)}?page={page}&per_page={perPage}", ct);

    public Task<IReadOnlyList<Channel>> GetPublicChannelsForTeamAsync(string teamId, int page = 0, int perPage = 200, CancellationToken ct = default)
        => _api.GetAsync<IReadOnlyList<Channel>>($"/api/v4/teams/{teamId}/channels?page={page}&per_page={perPage}", ct);

    public Task<IReadOnlyList<Channel>> GetPrivateChannelsForTeamAsync(string teamId, int page = 0, int perPage = 200, CancellationToken ct = default)
        => _api.GetAsync<IReadOnlyList<Channel>>($"/api/v4/teams/{teamId}/channels/private?page={page}&per_page={perPage}", ct);

    public Task<IReadOnlyList<Channel>> SearchChannelsAsync(string teamId, string term, CancellationToken ct = default)
        => _api.PostAsync<IReadOnlyList<Channel>>(string.Format(ApiRoutes.ChannelsSearch, teamId), new { term }, ct);

    public Task<Channel> CreateChannelAsync(Channel channel, CancellationToken ct = default)
        => _api.PostAsync<Channel>(ApiRoutes.Channels, channel, ct);

    public Task<Channel> UpdateChannelAsync(string channelId, Channel channel, CancellationToken ct = default)
        => _api.PutAsync<Channel>(string.Format(ApiRoutes.Channel, channelId), channel, ct);

    public Task<Channel> PatchChannelAsync(string channelId, Dictionary<string, object> patch, CancellationToken ct = default)
        => _api.PutAsync<Channel>(string.Format(ApiRoutes.Channel, channelId) + "/patch", patch, ct);

    public async Task DeleteChannelAsync(string channelId, CancellationToken ct = default)
        => await _api.DeleteAsync(string.Format(ApiRoutes.Channel, channelId), ct);

    public async Task RestoreChannelAsync(string channelId, CancellationToken ct = default)
        => await _api.PostAsync(string.Format(ApiRoutes.Channel, channelId) + "/restore", ct: ct);

    public Task<Channel> CreateDirectChannelAsync(string userId1, string userId2, CancellationToken ct = default)
        => _api.PostAsync<Channel>(ApiRoutes.ChannelsDirect, new[] { userId1, userId2 }, ct);

    public Task<Channel> CreateGroupChannelAsync(IEnumerable<string> userIds, CancellationToken ct = default)
        => _api.PostAsync<Channel>(ApiRoutes.ChannelsGroup, userIds.ToArray(), ct);

    public Task<ChannelMember> AddChannelMemberAsync(string channelId, string userId, CancellationToken ct = default)
        => _api.PostAsync<ChannelMember>(string.Format(ApiRoutes.ChannelMembers, channelId), new { user_id = userId }, ct);

    public async Task RemoveChannelMemberAsync(string channelId, string userId, CancellationToken ct = default)
        => await _api.DeleteAsync(string.Format(ApiRoutes.ChannelMember, channelId, userId), ct);

    public Task<PagedResult<ChannelMember>> GetChannelMembersAsync(string channelId, int page = 0, int perPage = 60, CancellationToken ct = default)
        => _api.GetPagedAsync<ChannelMember>(string.Format(ApiRoutes.ChannelMembers, channelId), page, perPage, ct);

    public Task<ChannelMember> GetChannelMemberAsync(string channelId, string userId, CancellationToken ct = default)
        => _api.GetAsync<ChannelMember>(string.Format(ApiRoutes.ChannelMember, channelId, userId), ct);

    public Task<IReadOnlyList<ChannelMember>> GetChannelMembersForUserAsync(string userId, string teamId, CancellationToken ct = default)
        => _api.GetAsync<IReadOnlyList<ChannelMember>>(string.Format(ApiRoutes.UserChannelMembers, userId, teamId), ct);

    public Task<ChannelStats> GetChannelStatsAsync(string channelId, CancellationToken ct = default)
        => _api.GetAsync<ChannelStats>(string.Format(ApiRoutes.ChannelStats, channelId), ct);

    public Task<IReadOnlyList<Post>> GetPinnedPostsAsync(string channelId, CancellationToken ct = default)
        => _api.GetAsync<IReadOnlyList<Post>>(string.Format(ApiRoutes.ChannelPinned, channelId), ct);

    public async Task UpdateChannelMemberNotifyPropsAsync(string channelId, string userId, ChannelNotifyProps props, CancellationToken ct = default)
        => await _api.PutAsync(string.Format(ApiRoutes.ChannelMember, channelId, userId) + "/notify_props", props, ct);

    public async Task UpdateChannelMemberRolesAsync(string channelId, string userId, string roles, CancellationToken ct = default)
        => await _api.PutAsync(string.Format(ApiRoutes.ChannelMember, channelId, userId) + "/roles", new { roles }, ct);

    public async Task ViewChannelAsync(string userId, string channelId, string? prevChannelId = null, CancellationToken ct = default)
        => await _api.PostAsync(ApiRoutes.ChannelViewPost, new { channel_id = channelId, prev_channel_id = prevChannelId }, ct);

    public Task<IReadOnlyList<ChannelCategory>> GetSidebarCategoriesAsync(string userId, string teamId, CancellationToken ct = default)
        => _api.GetAsync<IReadOnlyList<ChannelCategory>>(string.Format(ApiRoutes.ChannelCategories, userId, teamId), ct);

    public Task<ChannelCategory> UpdateSidebarCategoryAsync(string userId, string teamId, string categoryId, ChannelCategory category, CancellationToken ct = default)
        => _api.PutAsync<ChannelCategory>(string.Format(ApiRoutes.ChannelCategory, userId, teamId, categoryId), category, ct);
}
