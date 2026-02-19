using Fluenzi.Mattermost.Client.Internal;
using Fluenzi.Mattermost.Constants;
using Fluenzi.Mattermost.Interfaces.Client;
using Fluenzi.Mattermost.Models.Channels;
using Fluenzi.Mattermost.Models.Common;
using Fluenzi.Mattermost.Models.System;

namespace Fluenzi.Mattermost.Client.Services;

public class SchemeApiClient : ISchemeApi
{
    private readonly ApiRequestHandler _api;
    public SchemeApiClient(ApiRequestHandler api) => _api = api;

    public Task<Scheme> GetSchemeAsync(string schemeId, CancellationToken ct = default)
        => _api.GetAsync<Scheme>(string.Format(ApiRoutes.Scheme, schemeId), ct);

    public Task<PagedResult<Scheme>> GetSchemesAsync(string? scope = null, int page = 0, int perPage = 60, CancellationToken ct = default)
    {
        var url = ApiRoutes.Schemes + $"?page={page}&per_page={perPage}";
        if (scope != null) url += $"&scope={scope}";
        return _api.GetAsync<PagedResult<Scheme>>(url, ct);
    }

    public Task<Scheme> CreateSchemeAsync(Scheme scheme, CancellationToken ct = default)
        => _api.PostAsync<Scheme>(ApiRoutes.Schemes, scheme, ct);

    public Task<Scheme> PatchSchemeAsync(string schemeId, Dictionary<string, object> patch, CancellationToken ct = default)
        => _api.PatchAsync<Scheme>(string.Format(ApiRoutes.SchemePatch, schemeId), patch, ct);

    public async Task DeleteSchemeAsync(string schemeId, CancellationToken ct = default)
        => await _api.DeleteAsync(string.Format(ApiRoutes.Scheme, schemeId), ct);

    public Task<PagedResult<Channel>> GetChannelsForSchemeAsync(string schemeId, int page = 0, int perPage = 60, CancellationToken ct = default)
        => _api.GetPagedAsync<Channel>(string.Format(ApiRoutes.SchemeChannels, schemeId), page, perPage, ct);
}

public class ClusterApiClient : IClusterApi
{
    private readonly ApiRequestHandler _api;
    public ClusterApiClient(ApiRequestHandler api) => _api = api;

    public Task<IReadOnlyList<ClusterInfo>> GetClusterStatusAsync(CancellationToken ct = default)
        => _api.GetAsync<IReadOnlyList<ClusterInfo>>(ApiRoutes.ClusterStatus, ct);
}

public class BrandApiClient : IBrandApi
{
    private readonly ApiRequestHandler _api;
    public BrandApiClient(ApiRequestHandler api) => _api = api;

    public Task<byte[]> GetBrandImageAsync(CancellationToken ct = default)
        => _api.GetBytesAsync(ApiRoutes.BrandImage, ct);

    public async Task UploadBrandImageAsync(Stream image, CancellationToken ct = default)
    {
        using var content = new MultipartFormDataContent();
        content.Add(new StreamContent(image), "image", "brand.png");
        await _api.PostMultipartAsync(ApiRoutes.BrandImage, content, ct);
    }

    public async Task DeleteBrandImageAsync(CancellationToken ct = default)
        => await _api.DeleteAsync(ApiRoutes.BrandImage, ct);
}

public class OpenGraphApiClient : IOpenGraphApi
{
    private readonly ApiRequestHandler _api;
    public OpenGraphApiClient(ApiRequestHandler api) => _api = api;

    public Task<OpenGraphMetadata> GetOpenGraphMetadataAsync(string url, CancellationToken ct = default)
        => _api.PostAsync<OpenGraphMetadata>(ApiRoutes.OpenGraph, new { url }, ct);
}

public class BleveApiClient : IBleveApi
{
    private readonly ApiRequestHandler _api;
    public BleveApiClient(ApiRequestHandler api) => _api = api;

    public async Task PurgeBleveIndexesAsync(CancellationToken ct = default)
        => await _api.PostAsync(ApiRoutes.BlevePurge, ct: ct);
}

public class UploadApiClient : IUploadApi
{
    private readonly ApiRequestHandler _api;
    public UploadApiClient(ApiRequestHandler api) => _api = api;

    public Task<UploadSession> CreateUploadSessionAsync(string channelId, string filename, long fileSize, CancellationToken ct = default)
        => _api.PostAsync<UploadSession>(ApiRoutes.Uploads, new { channel_id = channelId, filename, file_size = fileSize }, ct);

    public Task<UploadSession> GetUploadSessionAsync(string uploadId, CancellationToken ct = default)
        => _api.GetAsync<UploadSession>(string.Format(ApiRoutes.Upload, uploadId), ct);

    public async Task<Models.Files.FileInfo> UploadDataAsync(string uploadId, Stream data, CancellationToken ct = default)
    {
        using var content = new MultipartFormDataContent();
        content.Add(new StreamContent(data), "data", "upload");
        return await _api.PostMultipartAsync<Models.Files.FileInfo>(string.Format(ApiRoutes.Upload, uploadId), content, ct);
    }
}

public class SharedChannelApiClient : ISharedChannelApi
{
    private readonly ApiRequestHandler _api;
    public SharedChannelApiClient(ApiRequestHandler api) => _api = api;

    public Task<PagedResult<SharedChannel>> GetSharedChannelsAsync(string teamId, int page = 0, int perPage = 60, CancellationToken ct = default)
        => _api.GetPagedAsync<SharedChannel>(string.Format(ApiRoutes.SharedChannels, teamId), page, perPage, ct);

    public Task<IReadOnlyList<SharedChannelRemote>> GetSharedChannelRemotesAsync(string channelId, CancellationToken ct = default)
        => _api.GetAsync<IReadOnlyList<SharedChannelRemote>>(string.Format(ApiRoutes.SharedChannelRemotes, channelId), ct);
}

public class IPFilterApiClient : IIPFilterApi
{
    private readonly ApiRequestHandler _api;
    public IPFilterApiClient(ApiRequestHandler api) => _api = api;

    public Task<IPFilterConfig> GetIPFiltersAsync(CancellationToken ct = default)
        => _api.GetAsync<IPFilterConfig>(ApiRoutes.IPFilters, ct);

    public Task<IPFilterConfig> UpdateIPFiltersAsync(IPFilterConfig config, CancellationToken ct = default)
        => _api.PutAsync<IPFilterConfig>(ApiRoutes.IPFilters, config, ct);

    public Task<string> GetMyIPAsync(CancellationToken ct = default)
        => _api.GetAsync<string>(ApiRoutes.MyIP, ct);
}

public class OutgoingOAuthApiClient : IOutgoingOAuthApi
{
    private readonly ApiRequestHandler _api;
    public OutgoingOAuthApiClient(ApiRequestHandler api) => _api = api;

    public Task<PagedResult<OutgoingOAuthConnection>> GetOutgoingOAuthConnectionsAsync(int page = 0, int perPage = 60, CancellationToken ct = default)
        => _api.GetPagedAsync<OutgoingOAuthConnection>(ApiRoutes.OutgoingOAuthConnections, page, perPage, ct);

    public Task<OutgoingOAuthConnection> GetOutgoingOAuthConnectionAsync(string connectionId, CancellationToken ct = default)
        => _api.GetAsync<OutgoingOAuthConnection>(string.Format(ApiRoutes.OutgoingOAuthConnection, connectionId), ct);

    public Task<OutgoingOAuthConnection> CreateOutgoingOAuthConnectionAsync(OutgoingOAuthConnection connection, CancellationToken ct = default)
        => _api.PostAsync<OutgoingOAuthConnection>(ApiRoutes.OutgoingOAuthConnections, connection, ct);

    public Task<OutgoingOAuthConnection> UpdateOutgoingOAuthConnectionAsync(string connectionId, OutgoingOAuthConnection connection, CancellationToken ct = default)
        => _api.PutAsync<OutgoingOAuthConnection>(string.Format(ApiRoutes.OutgoingOAuthConnection, connectionId), connection, ct);

    public async Task DeleteOutgoingOAuthConnectionAsync(string connectionId, CancellationToken ct = default)
        => await _api.DeleteAsync(string.Format(ApiRoutes.OutgoingOAuthConnection, connectionId), ct);
}
