using Fluenzi.Mattermost.Models.System;
using Fluenzi.Mattermost.Models.Channels;
using Fluenzi.Mattermost.Models.Common;

namespace Fluenzi.Mattermost.Interfaces.Client;

public interface ISchemeApi
{
    Task<Scheme> GetSchemeAsync(string schemeId, CancellationToken ct = default);
    Task<PagedResult<Scheme>> GetSchemesAsync(string? scope = null, int page = 0, int perPage = 60, CancellationToken ct = default);
    Task<Scheme> CreateSchemeAsync(Scheme scheme, CancellationToken ct = default);
    Task<Scheme> PatchSchemeAsync(string schemeId, Dictionary<string, object> patch, CancellationToken ct = default);
    Task DeleteSchemeAsync(string schemeId, CancellationToken ct = default);
    Task<PagedResult<Channel>> GetChannelsForSchemeAsync(string schemeId, int page = 0, int perPage = 60, CancellationToken ct = default);
}

public interface IClusterApi
{
    Task<IReadOnlyList<ClusterInfo>> GetClusterStatusAsync(CancellationToken ct = default);
}

public interface IBrandApi
{
    Task<byte[]> GetBrandImageAsync(CancellationToken ct = default);
    Task UploadBrandImageAsync(Stream image, CancellationToken ct = default);
    Task DeleteBrandImageAsync(CancellationToken ct = default);
}

public interface IOpenGraphApi
{
    Task<OpenGraphMetadata> GetOpenGraphMetadataAsync(string url, CancellationToken ct = default);
}

public interface IBleveApi
{
    Task PurgeBleveIndexesAsync(CancellationToken ct = default);
}

public interface IUploadApi
{
    Task<UploadSession> CreateUploadSessionAsync(string channelId, string filename, long fileSize, CancellationToken ct = default);
    Task<UploadSession> GetUploadSessionAsync(string uploadId, CancellationToken ct = default);
    Task<Fluenzi.Mattermost.Models.Files.FileInfo> UploadDataAsync(string uploadId, Stream data, CancellationToken ct = default);
}

public interface ISharedChannelApi
{
    Task<PagedResult<SharedChannel>> GetSharedChannelsAsync(string teamId, int page = 0, int perPage = 60, CancellationToken ct = default);
    Task<IReadOnlyList<SharedChannelRemote>> GetSharedChannelRemotesAsync(string channelId, CancellationToken ct = default);
}

public interface IIPFilterApi
{
    Task<IPFilterConfig> GetIPFiltersAsync(CancellationToken ct = default);
    Task<IPFilterConfig> UpdateIPFiltersAsync(IPFilterConfig config, CancellationToken ct = default);
    Task<string> GetMyIPAsync(CancellationToken ct = default);
}

public interface IOutgoingOAuthApi
{
    Task<PagedResult<OutgoingOAuthConnection>> GetOutgoingOAuthConnectionsAsync(int page = 0, int perPage = 60, CancellationToken ct = default);
    Task<OutgoingOAuthConnection> GetOutgoingOAuthConnectionAsync(string connectionId, CancellationToken ct = default);
    Task<OutgoingOAuthConnection> CreateOutgoingOAuthConnectionAsync(OutgoingOAuthConnection connection, CancellationToken ct = default);
    Task<OutgoingOAuthConnection> UpdateOutgoingOAuthConnectionAsync(string connectionId, OutgoingOAuthConnection connection, CancellationToken ct = default);
    Task DeleteOutgoingOAuthConnectionAsync(string connectionId, CancellationToken ct = default);
}
