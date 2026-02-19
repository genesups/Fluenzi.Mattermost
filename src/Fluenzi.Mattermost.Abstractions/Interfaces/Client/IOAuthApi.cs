using Fluenzi.Mattermost.Models.Integrations;
using Fluenzi.Mattermost.Models.Common;

namespace Fluenzi.Mattermost.Interfaces.Client;

public interface IOAuthApi
{
    Task<PagedResult<OAuthApp>> GetOAuthAppsAsync(int page = 0, int perPage = 60, CancellationToken ct = default);
    Task<OAuthApp> CreateOAuthAppAsync(OAuthApp app, CancellationToken ct = default);
    Task<OAuthApp> GetOAuthAppAsync(string appId, CancellationToken ct = default);
    Task<OAuthApp> UpdateOAuthAppAsync(string appId, OAuthApp app, CancellationToken ct = default);
    Task DeleteOAuthAppAsync(string appId, CancellationToken ct = default);
    Task<OAuthApp> RegenerateOAuthAppSecretAsync(string appId, CancellationToken ct = default);
}
