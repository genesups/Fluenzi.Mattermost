using Fluenzi.Mattermost.Models.Groups;
using Fluenzi.Mattermost.Models.Common;

namespace Fluenzi.Mattermost.Interfaces.Client;

public interface IGroupApi
{
    Task<PagedResult<Group>> GetGroupsAsync(int page = 0, int perPage = 60, CancellationToken ct = default);
    Task<Group> GetGroupAsync(string groupId, CancellationToken ct = default);
    Task<PagedResult<GroupMember>> GetGroupMembersAsync(string groupId, int page = 0, int perPage = 60, CancellationToken ct = default);
    Task<GroupStats> GetGroupStatsAsync(string groupId, CancellationToken ct = default);
    Task<IReadOnlyList<Group>> GetGroupsByChannelAsync(string channelId, CancellationToken ct = default);
    Task<IReadOnlyList<Group>> GetGroupsByTeamAsync(string teamId, CancellationToken ct = default);
}
