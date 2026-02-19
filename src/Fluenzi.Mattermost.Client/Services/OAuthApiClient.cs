using Fluenzi.Mattermost.Client.Internal;
using Fluenzi.Mattermost.Constants;
using Fluenzi.Mattermost.Interfaces.Client;
using Fluenzi.Mattermost.Models.Common;
using Fluenzi.Mattermost.Models.Integrations;

namespace Fluenzi.Mattermost.Client.Services;

public class OAuthApiClient : IOAuthApi
{
    private readonly ApiRequestHandler _api;
    public OAuthApiClient(ApiRequestHandler api) => _api = api;

    public Task<PagedResult<OAuthApp>> GetOAuthAppsAsync(int page = 0, int perPage = 60, CancellationToken ct = default)
        => _api.GetPagedAsync<OAuthApp>(ApiRoutes.OAuthApps, page, perPage, ct);

    public Task<OAuthApp> CreateOAuthAppAsync(OAuthApp app, CancellationToken ct = default)
        => _api.PostAsync<OAuthApp>(ApiRoutes.OAuthApps, app, ct);

    public Task<OAuthApp> GetOAuthAppAsync(string appId, CancellationToken ct = default)
        => _api.GetAsync<OAuthApp>(string.Format(ApiRoutes.OAuthApp, appId), ct);

    public Task<OAuthApp> UpdateOAuthAppAsync(string appId, OAuthApp app, CancellationToken ct = default)
        => _api.PutAsync<OAuthApp>(string.Format(ApiRoutes.OAuthApp, appId), app, ct);

    public async Task DeleteOAuthAppAsync(string appId, CancellationToken ct = default)
        => await _api.DeleteAsync(string.Format(ApiRoutes.OAuthApp, appId), ct);

    public Task<OAuthApp> RegenerateOAuthAppSecretAsync(string appId, CancellationToken ct = default)
        => _api.PostAsync<OAuthApp>(string.Format(ApiRoutes.OAuthApp, appId) + "/regen_secret", ct: ct);
}
