using Fluenzi.Mattermost.Client.Internal;
using Fluenzi.Mattermost.Constants;
using Fluenzi.Mattermost.Interfaces.Client;
using Fluenzi.Mattermost.Models.Roles;

namespace Fluenzi.Mattermost.Client.Services;

public class RoleApiClient : IRoleApi
{
    private readonly ApiRequestHandler _api;
    public RoleApiClient(ApiRequestHandler api) => _api = api;

    public Task<Role> GetRoleAsync(string roleId, CancellationToken ct = default)
        => _api.GetAsync<Role>(string.Format(ApiRoutes.Role, roleId), ct);

    public Task<Role> GetRoleByNameAsync(string name, CancellationToken ct = default)
        => _api.GetAsync<Role>(string.Format(ApiRoutes.RoleByName, name), ct);

    public Task<IReadOnlyList<Role>> GetRolesByNamesAsync(IEnumerable<string> names, CancellationToken ct = default)
        => _api.PostAsync<IReadOnlyList<Role>>(ApiRoutes.RolesByNames, names.ToArray(), ct);

    public Task<Role> PatchRoleAsync(string roleId, Dictionary<string, object> patch, CancellationToken ct = default)
        => _api.PutAsync<Role>(string.Format(ApiRoutes.RolePatch, roleId), patch, ct);
}
