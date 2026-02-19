using Fluenzi.Mattermost.Client.Internal;
using Fluenzi.Mattermost.Constants;
using Fluenzi.Mattermost.Interfaces.Client;
using Fluenzi.Mattermost.Models.Channels;
using Fluenzi.Mattermost.Models.Common;
using Fluenzi.Mattermost.Models.Compliance;
using Fluenzi.Mattermost.Models.Groups;
using Fluenzi.Mattermost.Models.Jobs;
using Fluenzi.Mattermost.Models.System;

namespace Fluenzi.Mattermost.Client.Services;

public class ComplianceApiClient : IComplianceApi
{
    private readonly ApiRequestHandler _api;
    public ComplianceApiClient(ApiRequestHandler api) => _api = api;

    public Task<ComplianceReport> CreateComplianceReportAsync(ComplianceReport report, CancellationToken ct = default)
        => _api.PostAsync<ComplianceReport>(ApiRoutes.ComplianceReports, report, ct);

    public Task<PagedResult<ComplianceReport>> GetComplianceReportsAsync(int page = 0, int perPage = 60, CancellationToken ct = default)
        => _api.GetPagedAsync<ComplianceReport>(ApiRoutes.ComplianceReports, page, perPage, ct);

    public Task<ComplianceReport> GetComplianceReportAsync(string reportId, CancellationToken ct = default)
        => _api.GetAsync<ComplianceReport>(string.Format(ApiRoutes.ComplianceReport, reportId), ct);

    public Task<byte[]> DownloadComplianceReportAsync(string reportId, CancellationToken ct = default)
        => _api.GetBytesAsync(string.Format(ApiRoutes.ComplianceReportDownload, reportId), ct);
}

public class DataRetentionApiClient : IDataRetentionApi
{
    private readonly ApiRequestHandler _api;
    public DataRetentionApiClient(ApiRequestHandler api) => _api = api;

    public Task<DataRetentionPolicy> GetDataRetentionPolicyAsync(CancellationToken ct = default)
        => _api.GetAsync<DataRetentionPolicy>(ApiRoutes.DataRetention, ct);

    public Task<PagedResult<DataRetentionPolicy>> GetDataRetentionPoliciesAsync(int page = 0, int perPage = 60, CancellationToken ct = default)
        => _api.GetPagedAsync<DataRetentionPolicy>(ApiRoutes.DataRetentionPolicies, page, perPage, ct);
}

public class PluginApiClient : IPluginApi
{
    private readonly ApiRequestHandler _api;
    public PluginApiClient(ApiRequestHandler api) => _api = api;

    public Task<IReadOnlyList<PluginManifest>> GetPluginsAsync(CancellationToken ct = default)
        => _api.GetAsync<IReadOnlyList<PluginManifest>>(ApiRoutes.Plugins, ct);

    public async Task<PluginManifest> InstallPluginAsync(Stream plugin, bool force = false, CancellationToken ct = default)
    {
        using var content = new MultipartFormDataContent();
        content.Add(new StreamContent(plugin), "plugin", "plugin.tar.gz");
        var url = ApiRoutes.Plugins;
        if (force) url += "?force=true";
        return await _api.PostMultipartAsync<PluginManifest>(url, content, ct);
    }

    public async Task RemovePluginAsync(string pluginId, CancellationToken ct = default)
        => await _api.DeleteAsync(string.Format(ApiRoutes.Plugin, pluginId), ct);

    public async Task EnablePluginAsync(string pluginId, CancellationToken ct = default)
        => await _api.PostAsync(string.Format(ApiRoutes.PluginEnable, pluginId), ct: ct);

    public async Task DisablePluginAsync(string pluginId, CancellationToken ct = default)
        => await _api.PostAsync(string.Format(ApiRoutes.PluginDisable, pluginId), ct: ct);

    public Task<IReadOnlyList<PluginStatus>> GetPluginStatusesAsync(CancellationToken ct = default)
        => _api.GetAsync<IReadOnlyList<PluginStatus>>(ApiRoutes.PluginStatuses, ct);

    public Task<IReadOnlyList<PluginManifest>> GetMarketplacePluginsAsync(CancellationToken ct = default)
        => _api.GetAsync<IReadOnlyList<PluginManifest>>(ApiRoutes.PluginMarketplace, ct);
}

public class JobApiClient : IJobApi
{
    private readonly ApiRequestHandler _api;
    public JobApiClient(ApiRequestHandler api) => _api = api;

    public Task<PagedResult<Job>> GetJobsAsync(int page = 0, int perPage = 60, CancellationToken ct = default)
        => _api.GetPagedAsync<Job>(ApiRoutes.Jobs, page, perPage, ct);

    public Task<Job> GetJobAsync(string jobId, CancellationToken ct = default)
        => _api.GetAsync<Job>(string.Format(ApiRoutes.Job, jobId), ct);

    public Task<Job> CreateJobAsync(Job job, CancellationToken ct = default)
        => _api.PostAsync<Job>(ApiRoutes.Jobs, job, ct);

    public async Task CancelJobAsync(string jobId, CancellationToken ct = default)
        => await _api.PostAsync(string.Format(ApiRoutes.JobCancel, jobId), ct: ct);

    public Task<PagedResult<Job>> GetJobsByTypeAsync(string type, int page = 0, int perPage = 60, CancellationToken ct = default)
        => _api.GetPagedAsync<Job>(string.Format(ApiRoutes.JobsByType, type), page, perPage, ct);
}

public class LdapApiClient : ILdapApi
{
    private readonly ApiRequestHandler _api;
    public LdapApiClient(ApiRequestHandler api) => _api = api;

    public async Task SyncLdapAsync(CancellationToken ct = default)
        => await _api.PostAsync(ApiRoutes.LdapSync, ct: ct);

    public async Task TestLdapAsync(CancellationToken ct = default)
        => await _api.PostAsync(ApiRoutes.LdapTest, ct: ct);

    public async Task<IReadOnlyList<Group>> GetLdapGroupsAsync(int page = 0, int perPage = 60, CancellationToken ct = default)
    {
        var result = await _api.GetPagedAsync<Group>(ApiRoutes.LdapGroups, page, perPage, ct);
        return result.Items;
    }
}

public class SamlApiClient : ISamlApi
{
    private readonly ApiRequestHandler _api;
    public SamlApiClient(ApiRequestHandler api) => _api = api;

    public Task<string> GetSamlMetadataAsync(CancellationToken ct = default)
        => _api.GetAsync<string>(ApiRoutes.SamlMetadata, ct);

    public async Task UploadSamlCertificateAsync(string certType, Stream certificate, CancellationToken ct = default)
    {
        using var content = new MultipartFormDataContent();
        content.Add(new StreamContent(certificate), "certificate", "cert.pem");
        await _api.PostMultipartAsync(string.Format(ApiRoutes.SamlCertificate, certType), content, ct);
    }

    public async Task DeleteSamlCertificateAsync(string certType, CancellationToken ct = default)
        => await _api.DeleteAsync(string.Format(ApiRoutes.SamlCertificate, certType), ct);
}

public class ElasticsearchApiClient : IElasticsearchApi
{
    private readonly ApiRequestHandler _api;
    public ElasticsearchApiClient(ApiRequestHandler api) => _api = api;

    public async Task TestElasticsearchAsync(CancellationToken ct = default)
        => await _api.PostAsync(ApiRoutes.ElasticsearchTest, ct: ct);

    public async Task PurgeElasticsearchIndexesAsync(CancellationToken ct = default)
        => await _api.PostAsync(ApiRoutes.ElasticsearchPurge, ct: ct);
}

public class BookmarkApiClient : IBookmarkApi
{
    private readonly ApiRequestHandler _api;
    public BookmarkApiClient(ApiRequestHandler api) => _api = api;

    public Task<IReadOnlyList<ChannelBookmark>> GetChannelBookmarksAsync(string channelId, CancellationToken ct = default)
        => _api.GetAsync<IReadOnlyList<ChannelBookmark>>(string.Format(ApiRoutes.ChannelBookmarks, channelId), ct);

    public Task<ChannelBookmark> CreateChannelBookmarkAsync(string channelId, ChannelBookmark bookmark, CancellationToken ct = default)
        => _api.PostAsync<ChannelBookmark>(string.Format(ApiRoutes.ChannelBookmarks, channelId), bookmark, ct);

    public Task<ChannelBookmark> UpdateChannelBookmarkAsync(string channelId, string bookmarkId, ChannelBookmark bookmark, CancellationToken ct = default)
        => _api.PatchAsync<ChannelBookmark>(string.Format(ApiRoutes.ChannelBookmark, channelId, bookmarkId), bookmark, ct);

    public async Task DeleteChannelBookmarkAsync(string channelId, string bookmarkId, CancellationToken ct = default)
        => await _api.DeleteAsync(string.Format(ApiRoutes.ChannelBookmark, channelId, bookmarkId), ct);

    public async Task UpdateChannelBookmarkSortOrderAsync(string channelId, IEnumerable<string> bookmarkIds, CancellationToken ct = default)
        => await _api.PostAsync(string.Format(ApiRoutes.ChannelBookmarkSort, channelId), bookmarkIds.ToArray(), ct);
}

public class ImportExportApiClient : IImportExportApi
{
    private readonly ApiRequestHandler _api;
    public ImportExportApiClient(ApiRequestHandler api) => _api = api;

    public Task<IReadOnlyList<Dictionary<string, object>>> GetExportsAsync(CancellationToken ct = default)
        => _api.GetAsync<IReadOnlyList<Dictionary<string, object>>>(ApiRoutes.Exports, ct);

    public async Task CreateExportAsync(CancellationToken ct = default)
        => await _api.PostAsync(ApiRoutes.Exports, ct: ct);

    public Task<byte[]> DownloadExportAsync(string exportName, CancellationToken ct = default)
        => _api.GetBytesAsync(string.Format(ApiRoutes.Export, exportName), ct);

    public async Task DeleteExportAsync(string exportName, CancellationToken ct = default)
        => await _api.DeleteAsync(string.Format(ApiRoutes.Export, exportName), ct);
}
