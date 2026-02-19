using Fluenzi.Mattermost.Models.Files;

namespace Fluenzi.Mattermost.Interfaces.Client;

public interface IFileApi
{
    Task<FileUploadResponse> UploadFileAsync(string channelId, string fileName, Stream content, Action<int>? onProgress = null, CancellationToken ct = default);
    Task<byte[]> GetFileAsync(string fileId, CancellationToken ct = default);
    Task<Stream> GetFileStreamAsync(string fileId, CancellationToken ct = default);
    Task<Models.Files.FileInfo> GetFileInfoAsync(string fileId, CancellationToken ct = default);
    Task<byte[]> GetFileThumbnailAsync(string fileId, CancellationToken ct = default);
    Task<byte[]> GetFilePreviewAsync(string fileId, CancellationToken ct = default);
    Task<string> GetFileLinkAsync(string fileId, CancellationToken ct = default);
}
