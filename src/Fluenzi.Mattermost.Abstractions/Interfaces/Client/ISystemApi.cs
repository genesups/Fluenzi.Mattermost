using Fluenzi.Mattermost.Models.System;
using Fluenzi.Mattermost.Models.Compliance;

namespace Fluenzi.Mattermost.Interfaces.Client;

public interface ISystemApi
{
    Task<Dictionary<string, object>> GetConfigAsync(CancellationToken ct = default);
    Task<Dictionary<string, object>> UpdateConfigAsync(Dictionary<string, object> config, CancellationToken ct = default);
    Task ReloadConfigAsync(CancellationToken ct = default);
    Task<Dictionary<string, string>> GetClientConfigAsync(CancellationToken ct = default);
    Task<bool> PingAsync(CancellationToken ct = default);
    Task<ServerLicense?> GetLicenseAsync(CancellationToken ct = default);
    Task<Dictionary<string, string>> GetClientLicenseAsync(CancellationToken ct = default);
    Task<Dictionary<string, object>> GetAnalyticsAsync(string? name = null, string? teamId = null, CancellationToken ct = default);
    Task<IReadOnlyList<string>> GetLogsAsync(int page = 0, int perPage = 10000, CancellationToken ct = default);
    Task<IReadOnlyList<AuditEntry>> GetAuditsAsync(int page = 0, int perPage = 60, CancellationToken ct = default);
    Task InvalidateCachesAsync(CancellationToken ct = default);
    Task RecycleDatabaseConnectionsAsync(CancellationToken ct = default);
    Task TestEmailAsync(CancellationToken ct = default);
    Task TestSiteUrlAsync(string siteUrl, CancellationToken ct = default);
    Task<ServerInfo> GetServerInfoAsync(CancellationToken ct = default);
}
