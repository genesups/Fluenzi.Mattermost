using Fluenzi.Mattermost.Client.Internal;
using Fluenzi.Mattermost.Constants;
using Fluenzi.Mattermost.Interfaces.Client;
using Fluenzi.Mattermost.Models.Common;
using Fluenzi.Mattermost.Models.Groups;

namespace Fluenzi.Mattermost.Client.Services;

public class GroupApiClient : IGroupApi
{
    private readonly ApiRequestHandler _api;
    public GroupApiClient(ApiRequestHandler api) => _api = api;

    public Task<PagedResult<Group>> GetGroupsAsync(int page = 0, int perPage = 60, CancellationToken ct = default)
        => _api.GetPagedAsync<Group>(ApiRoutes.Groups, page, perPage, ct);

    public Task<Group> GetGroupAsync(string groupId, CancellationToken ct = default)
        => _api.GetAsync<Group>(string.Format(ApiRoutes.Group, groupId), ct);

    public Task<PagedResult<GroupMember>> GetGroupMembersAsync(string groupId, int page = 0, int perPage = 60, CancellationToken ct = default)
        => _api.GetPagedAsync<GroupMember>(string.Format(ApiRoutes.GroupMembers, groupId), page, perPage, ct);

    public Task<GroupStats> GetGroupStatsAsync(string groupId, CancellationToken ct = default)
        => _api.GetAsync<GroupStats>(string.Format(ApiRoutes.GroupStats, groupId), ct);

    public Task<IReadOnlyList<Group>> GetGroupsByChannelAsync(string channelId, CancellationToken ct = default)
        => _api.GetAsync<IReadOnlyList<Group>>(string.Format(ApiRoutes.ChannelGroups, channelId), ct);

    public Task<IReadOnlyList<Group>> GetGroupsByTeamAsync(string teamId, CancellationToken ct = default)
        => _api.GetAsync<IReadOnlyList<Group>>(string.Format(ApiRoutes.TeamGroups, teamId), ct);
}
