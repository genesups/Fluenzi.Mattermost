using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Files;

/// <summary>
/// Represents the response from a file upload operation.
/// </summary>
public record FileUploadResponse
{
    [JsonPropertyName("file_infos")]
    public FileInfo[]? FileInfos { get; init; }

    [JsonPropertyName("client_ids")]
    public string[]? ClientIds { get; init; }
}
