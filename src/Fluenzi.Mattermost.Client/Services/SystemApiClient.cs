using Fluenzi.Mattermost.Client.Internal;
using Fluenzi.Mattermost.Constants;
using Fluenzi.Mattermost.Interfaces.Client;
using Fluenzi.Mattermost.Models.Compliance;
using Fluenzi.Mattermost.Models.System;

namespace Fluenzi.Mattermost.Client.Services;

public class SystemApiClient : ISystemApi
{
    private readonly ApiRequestHandler _api;
    public SystemApiClient(ApiRequestHandler api) => _api = api;

    public Task<Dictionary<string, object>> GetConfigAsync(CancellationToken ct = default)
        => _api.GetAsync<Dictionary<string, object>>(ApiRoutes.Config, ct);

    public Task<Dictionary<string, object>> UpdateConfigAsync(Dictionary<string, object> config, CancellationToken ct = default)
        => _api.PutAsync<Dictionary<string, object>>(ApiRoutes.Config, config, ct);

    public async Task ReloadConfigAsync(CancellationToken ct = default)
        => await _api.PostAsync(ApiRoutes.ConfigReload, ct: ct);

    public Task<Dictionary<string, string>> GetClientConfigAsync(CancellationToken ct = default)
        => _api.GetAsync<Dictionary<string, string>>($"{ApiRoutes.ConfigClient}?format=old", ct);

    public async Task<bool> PingAsync(CancellationToken ct = default)
    {
        try
        {
            await _api.GetAsync<Dictionary<string, string>>(ApiRoutes.Ping, ct);
            return true;
        }
        catch { return false; }
    }

    public Task<ServerLicense?> GetLicenseAsync(CancellationToken ct = default)
        => _api.GetAsync<ServerLicense?>(ApiRoutes.License, ct);

    public Task<Dictionary<string, string>> GetClientLicenseAsync(CancellationToken ct = default)
        => _api.GetAsync<Dictionary<string, string>>($"{ApiRoutes.LicenseClient}?format=old", ct);

    public Task<Dictionary<string, object>> GetAnalyticsAsync(string? name = null, string? teamId = null, CancellationToken ct = default)
    {
        var url = ApiRoutes.Analytics;
        var sep = '?';
        if (name != null) { url += $"{sep}name={name}"; sep = '&'; }
        if (teamId != null) { url += $"{sep}team_id={teamId}"; }
        return _api.GetAsync<Dictionary<string, object>>(url, ct);
    }

    public Task<IReadOnlyList<string>> GetLogsAsync(int page = 0, int perPage = 10000, CancellationToken ct = default)
        => _api.GetAsync<IReadOnlyList<string>>($"{ApiRoutes.Logs}?page={page}&logs_per_page={perPage}", ct);

    public Task<IReadOnlyList<AuditEntry>> GetAuditsAsync(int page = 0, int perPage = 60, CancellationToken ct = default)
        => _api.GetAsync<IReadOnlyList<AuditEntry>>($"{ApiRoutes.Audits}?page={page}&per_page={perPage}", ct);

    public async Task InvalidateCachesAsync(CancellationToken ct = default)
        => await _api.PostAsync(ApiRoutes.Caches, ct: ct);

    public async Task RecycleDatabaseConnectionsAsync(CancellationToken ct = default)
        => await _api.PostAsync(ApiRoutes.Database, ct: ct);

    public async Task TestEmailAsync(CancellationToken ct = default)
        => await _api.PostAsync(ApiRoutes.TestEmail, ct: ct);

    public async Task TestSiteUrlAsync(string siteUrl, CancellationToken ct = default)
        => await _api.PostAsync(ApiRoutes.TestSiteUrl, new { site_url = siteUrl }, ct);

    public Task<ServerInfo> GetServerInfoAsync(CancellationToken ct = default)
        => _api.GetAsync<ServerInfo>(ApiRoutes.Ping, ct);
}
