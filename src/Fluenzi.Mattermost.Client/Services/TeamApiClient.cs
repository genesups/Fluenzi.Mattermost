using Fluenzi.Mattermost.Client.Internal;
using Fluenzi.Mattermost.Constants;
using Fluenzi.Mattermost.Interfaces.Client;
using Fluenzi.Mattermost.Models.Common;
using Fluenzi.Mattermost.Models.Teams;

namespace Fluenzi.Mattermost.Client.Services;

public class TeamApiClient : ITeamApi
{
    private readonly ApiRequestHandler _api;

    public TeamApiClient(ApiRequestHandler api) => _api = api;

    public Task<Team> GetTeamAsync(string teamId, CancellationToken ct = default)
        => _api.GetAsync<Team>(string.Format(ApiRoutes.Team, teamId), ct);

    public Task<Team> GetTeamByNameAsync(string name, CancellationToken ct = default)
        => _api.GetAsync<Team>(string.Format(ApiRoutes.TeamByName, name), ct);

    public Task<IReadOnlyList<Team>> GetMyTeamsAsync(int page = 0, int perPage = 60, CancellationToken ct = default)
        => _api.GetAsync<IReadOnlyList<Team>>($"{ApiRoutes.UserTeams.Replace("{0}", "me")}?page={page}&per_page={perPage}", ct);

    public Task<PagedResult<Team>> GetTeamsAsync(int page = 0, int perPage = 60, CancellationToken ct = default)
        => _api.GetPagedAsync<Team>(ApiRoutes.Teams, page, perPage, ct);

    public IAsyncEnumerable<Team> GetAllTeamsAsync(CancellationToken ct = default)
        => _api.GetAllPagesAsync<Team>(ApiRoutes.Teams, ct: ct);

    public Task<IReadOnlyList<Team>> SearchTeamsAsync(string term, CancellationToken ct = default)
        => _api.PostAsync<IReadOnlyList<Team>>(ApiRoutes.TeamsSearch, new { term }, ct);

    public Task<Team> CreateTeamAsync(Team team, CancellationToken ct = default)
        => _api.PostAsync<Team>(ApiRoutes.Teams, team, ct);

    public Task<Team> UpdateTeamAsync(string teamId, Team team, CancellationToken ct = default)
        => _api.PutAsync<Team>(string.Format(ApiRoutes.Team, teamId), team, ct);

    public async Task DeleteTeamAsync(string teamId, bool permanent = false, CancellationToken ct = default)
    {
        var url = string.Format(ApiRoutes.Team, teamId);
        if (permanent) url += "?permanent=true";
        await _api.DeleteAsync(url, ct);
    }

    public Task<TeamMember> AddTeamMemberAsync(string teamId, string userId, CancellationToken ct = default)
        => _api.PostAsync<TeamMember>(string.Format(ApiRoutes.TeamMembers, teamId), new { user_id = userId, team_id = teamId }, ct);

    public async Task RemoveTeamMemberAsync(string teamId, string userId, CancellationToken ct = default)
        => await _api.DeleteAsync(string.Format(ApiRoutes.TeamMember, teamId, userId), ct);

    public Task<PagedResult<TeamMember>> GetTeamMembersAsync(string teamId, int page = 0, int perPage = 60, CancellationToken ct = default)
        => _api.GetPagedAsync<TeamMember>(string.Format(ApiRoutes.TeamMembers, teamId), page, perPage, ct);

    public Task<TeamMember> GetTeamMemberAsync(string teamId, string userId, CancellationToken ct = default)
        => _api.GetAsync<TeamMember>(string.Format(ApiRoutes.TeamMember, teamId, userId), ct);

    public Task<IReadOnlyList<TeamMember>> GetTeamMembersForUserAsync(string userId, CancellationToken ct = default)
        => _api.GetAsync<IReadOnlyList<TeamMember>>(string.Format(ApiRoutes.UserTeamMembers, userId), ct);

    public Task<TeamStats> GetTeamStatsAsync(string teamId, CancellationToken ct = default)
        => _api.GetAsync<TeamStats>(string.Format(ApiRoutes.TeamStats, teamId), ct);

    public Task<IReadOnlyList<TeamUnread>> GetTeamUnreadsForUserAsync(string userId, CancellationToken ct = default)
        => _api.GetAsync<IReadOnlyList<TeamUnread>>(string.Format(ApiRoutes.UserTeamUnread, userId), ct);

    public async Task UpdateTeamMemberRolesAsync(string teamId, string userId, string roles, CancellationToken ct = default)
        => await _api.PutAsync(string.Format(ApiRoutes.TeamMember, teamId, userId) + "/roles", new { roles }, ct);
}
