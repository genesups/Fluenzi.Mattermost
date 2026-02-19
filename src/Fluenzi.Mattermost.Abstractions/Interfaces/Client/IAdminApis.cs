using Fluenzi.Mattermost.Models.Compliance;
using Fluenzi.Mattermost.Models.System;
using Fluenzi.Mattermost.Models.Jobs;
using Fluenzi.Mattermost.Models.Groups;
using Fluenzi.Mattermost.Models.Channels;
using Fluenzi.Mattermost.Models.Common;

namespace Fluenzi.Mattermost.Interfaces.Client;

public interface IComplianceApi
{
    Task<ComplianceReport> CreateComplianceReportAsync(ComplianceReport report, CancellationToken ct = default);
    Task<PagedResult<ComplianceReport>> GetComplianceReportsAsync(int page = 0, int perPage = 60, CancellationToken ct = default);
    Task<ComplianceReport> GetComplianceReportAsync(string reportId, CancellationToken ct = default);
    Task<byte[]> DownloadComplianceReportAsync(string reportId, CancellationToken ct = default);
}

public interface IDataRetentionApi
{
    Task<DataRetentionPolicy> GetDataRetentionPolicyAsync(CancellationToken ct = default);
    Task<PagedResult<DataRetentionPolicy>> GetDataRetentionPoliciesAsync(int page = 0, int perPage = 60, CancellationToken ct = default);
}

public interface IPluginApi
{
    Task<IReadOnlyList<PluginManifest>> GetPluginsAsync(CancellationToken ct = default);
    Task<PluginManifest> InstallPluginAsync(Stream plugin, bool force = false, CancellationToken ct = default);
    Task RemovePluginAsync(string pluginId, CancellationToken ct = default);
    Task EnablePluginAsync(string pluginId, CancellationToken ct = default);
    Task DisablePluginAsync(string pluginId, CancellationToken ct = default);
    Task<IReadOnlyList<PluginStatus>> GetPluginStatusesAsync(CancellationToken ct = default);
    Task<IReadOnlyList<PluginManifest>> GetMarketplacePluginsAsync(CancellationToken ct = default);
}

public interface IJobApi
{
    Task<PagedResult<Job>> GetJobsAsync(int page = 0, int perPage = 60, CancellationToken ct = default);
    Task<Job> GetJobAsync(string jobId, CancellationToken ct = default);
    Task<Job> CreateJobAsync(Job job, CancellationToken ct = default);
    Task CancelJobAsync(string jobId, CancellationToken ct = default);
    Task<PagedResult<Job>> GetJobsByTypeAsync(string type, int page = 0, int perPage = 60, CancellationToken ct = default);
}

public interface ILdapApi
{
    Task SyncLdapAsync(CancellationToken ct = default);
    Task TestLdapAsync(CancellationToken ct = default);
    Task<IReadOnlyList<Group>> GetLdapGroupsAsync(int page = 0, int perPage = 60, CancellationToken ct = default);
}

public interface ISamlApi
{
    Task<string> GetSamlMetadataAsync(CancellationToken ct = default);
    Task UploadSamlCertificateAsync(string certType, Stream certificate, CancellationToken ct = default);
    Task DeleteSamlCertificateAsync(string certType, CancellationToken ct = default);
}

public interface IElasticsearchApi
{
    Task TestElasticsearchAsync(CancellationToken ct = default);
    Task PurgeElasticsearchIndexesAsync(CancellationToken ct = default);
}

public interface IBookmarkApi
{
    Task<IReadOnlyList<ChannelBookmark>> GetChannelBookmarksAsync(string channelId, CancellationToken ct = default);
    Task<ChannelBookmark> CreateChannelBookmarkAsync(string channelId, ChannelBookmark bookmark, CancellationToken ct = default);
    Task<ChannelBookmark> UpdateChannelBookmarkAsync(string channelId, string bookmarkId, ChannelBookmark bookmark, CancellationToken ct = default);
    Task DeleteChannelBookmarkAsync(string channelId, string bookmarkId, CancellationToken ct = default);
    Task UpdateChannelBookmarkSortOrderAsync(string channelId, IEnumerable<string> bookmarkIds, CancellationToken ct = default);
}

public interface IImportExportApi
{
    Task<IReadOnlyList<Dictionary<string, object>>> GetExportsAsync(CancellationToken ct = default);
    Task CreateExportAsync(CancellationToken ct = default);
    Task<byte[]> DownloadExportAsync(string exportName, CancellationToken ct = default);
    Task DeleteExportAsync(string exportName, CancellationToken ct = default);
}
