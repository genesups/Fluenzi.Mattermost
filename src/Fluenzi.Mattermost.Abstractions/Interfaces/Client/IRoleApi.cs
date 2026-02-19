using Fluenzi.Mattermost.Models.Roles;

namespace Fluenzi.Mattermost.Interfaces.Client;

public interface IRoleApi
{
    Task<Role> GetRoleAsync(string roleId, CancellationToken ct = default);
    Task<Role> GetRoleByNameAsync(string name, CancellationToken ct = default);
    Task<IReadOnlyList<Role>> GetRolesByNamesAsync(IEnumerable<string> names, CancellationToken ct = default);
    Task<Role> PatchRoleAsync(string roleId, Dictionary<string, object> patch, CancellationToken ct = default);
}
