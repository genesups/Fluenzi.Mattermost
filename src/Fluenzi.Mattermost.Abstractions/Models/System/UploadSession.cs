using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.System;

public record UploadSession
{
    [JsonPropertyName("id")] public string Id { get; init; } = "";
    [JsonPropertyName("type")] public string Type { get; init; } = ""; // "attachment", "import"
    [JsonPropertyName("create_at")] public long CreateAt { get; init; }
    [JsonPropertyName("user_id")] public string UserId { get; init; } = "";
    [JsonPropertyName("channel_id")] public string ChannelId { get; init; } = "";
    [JsonPropertyName("filename")] public string Filename { get; init; } = "";
    [JsonPropertyName("file_size")] public long FileSize { get; init; }
    [JsonPropertyName("file_offset")] public long FileOffset { get; init; }
}
