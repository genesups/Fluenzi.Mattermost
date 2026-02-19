using Fluenzi.Mattermost.Client.Internal;
using Fluenzi.Mattermost.Constants;
using Fluenzi.Mattermost.Interfaces.Client;
using Fluenzi.Mattermost.Models.Files;

namespace Fluenzi.Mattermost.Client.Services;

public class FileApiClient : IFileApi
{
    private readonly ApiRequestHandler _api;

    public FileApiClient(ApiRequestHandler api) => _api = api;

    public async Task<FileUploadResponse> UploadFileAsync(string channelId, string fileName, Stream content, Action<int>? onProgress = null, CancellationToken ct = default)
    {
        using var multipart = new MultipartFormDataContent();
        multipart.Add(new StringContent(channelId), "channel_id");
        multipart.Add(new StreamContent(content), "files", fileName);
        return await _api.PostMultipartAsync<FileUploadResponse>(ApiRoutes.Files, multipart, ct);
    }

    public Task<byte[]> GetFileAsync(string fileId, CancellationToken ct = default)
        => _api.GetBytesAsync(string.Format(ApiRoutes.File, fileId), ct);

    public Task<Stream> GetFileStreamAsync(string fileId, CancellationToken ct = default)
        => _api.GetStreamAsync(string.Format(ApiRoutes.File, fileId), ct);

    public Task<Models.Files.FileInfo> GetFileInfoAsync(string fileId, CancellationToken ct = default)
        => _api.GetAsync<Models.Files.FileInfo>(string.Format(ApiRoutes.FileInfo, fileId), ct);

    public Task<byte[]> GetFileThumbnailAsync(string fileId, CancellationToken ct = default)
        => _api.GetBytesAsync(string.Format(ApiRoutes.FileThumbnail, fileId), ct);

    public Task<byte[]> GetFilePreviewAsync(string fileId, CancellationToken ct = default)
        => _api.GetBytesAsync(string.Format(ApiRoutes.FilePreview, fileId), ct);

    public Task<string> GetFileLinkAsync(string fileId, CancellationToken ct = default)
        => _api.GetAsync<string>(string.Format(ApiRoutes.FileLink, fileId), ct);
}
