using Fluenzi.Mattermost.Models.Teams;
using Fluenzi.Mattermost.Models.Common;

namespace Fluenzi.Mattermost.Interfaces.Client;

public interface ITeamApi
{
    Task<Team> GetTeamAsync(string teamId, CancellationToken ct = default);
    Task<Team> GetTeamByNameAsync(string name, CancellationToken ct = default);
    Task<IReadOnlyList<Team>> GetMyTeamsAsync(int page = 0, int perPage = 60, CancellationToken ct = default);
    Task<PagedResult<Team>> GetTeamsAsync(int page = 0, int perPage = 60, CancellationToken ct = default);
    IAsyncEnumerable<Team> GetAllTeamsAsync(CancellationToken ct = default);
    Task<IReadOnlyList<Team>> SearchTeamsAsync(string term, CancellationToken ct = default);
    Task<Team> CreateTeamAsync(Team team, CancellationToken ct = default);
    Task<Team> UpdateTeamAsync(string teamId, Team team, CancellationToken ct = default);
    Task DeleteTeamAsync(string teamId, bool permanent = false, CancellationToken ct = default);
    Task<TeamMember> AddTeamMemberAsync(string teamId, string userId, CancellationToken ct = default);
    Task RemoveTeamMemberAsync(string teamId, string userId, CancellationToken ct = default);
    Task<PagedResult<TeamMember>> GetTeamMembersAsync(string teamId, int page = 0, int perPage = 60, CancellationToken ct = default);
    Task<TeamMember> GetTeamMemberAsync(string teamId, string userId, CancellationToken ct = default);
    Task<IReadOnlyList<TeamMember>> GetTeamMembersForUserAsync(string userId, CancellationToken ct = default);
    Task<TeamStats> GetTeamStatsAsync(string teamId, CancellationToken ct = default);
    Task<IReadOnlyList<TeamUnread>> GetTeamUnreadsForUserAsync(string userId, CancellationToken ct = default);
    Task UpdateTeamMemberRolesAsync(string teamId, string userId, string roles, CancellationToken ct = default);
}
