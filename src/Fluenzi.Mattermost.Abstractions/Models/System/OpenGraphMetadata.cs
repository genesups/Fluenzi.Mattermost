using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.System;

public record OpenGraphMetadata
{
    [JsonPropertyName("type")] public string Type { get; init; } = "";
    [JsonPropertyName("url")] public string Url { get; init; } = "";
    [JsonPropertyName("title")] public string Title { get; init; } = "";
    [JsonPropertyName("description")] public string Description { get; init; } = "";
    [JsonPropertyName("determiner")] public string Determiner { get; init; } = "";
    [JsonPropertyName("site_name")] public string SiteName { get; init; } = "";
    [JsonPropertyName("locale")] public string Locale { get; init; } = "";
    [JsonPropertyName("images")] public IReadOnlyList<OpenGraphImage>? Images { get; init; }
    [JsonPropertyName("audios")] public IReadOnlyList<OpenGraphAudio>? Audios { get; init; }
    [JsonPropertyName("videos")] public IReadOnlyList<OpenGraphVideo>? Videos { get; init; }
}

public record OpenGraphImage
{
    [JsonPropertyName("url")] public string Url { get; init; } = "";
    [JsonPropertyName("secure_url")] public string SecureUrl { get; init; } = "";
    [JsonPropertyName("type")] public string Type { get; init; } = "";
    [JsonPropertyName("width")] public int Width { get; init; }
    [JsonPropertyName("height")] public int Height { get; init; }
}

public record OpenGraphAudio
{
    [JsonPropertyName("url")] public string Url { get; init; } = "";
    [JsonPropertyName("secure_url")] public string SecureUrl { get; init; } = "";
    [JsonPropertyName("type")] public string Type { get; init; } = "";
}

public record OpenGraphVideo
{
    [JsonPropertyName("url")] public string Url { get; init; } = "";
    [JsonPropertyName("secure_url")] public string SecureUrl { get; init; } = "";
    [JsonPropertyName("type")] public string Type { get; init; } = "";
    [JsonPropertyName("width")] public int Width { get; init; }
    [JsonPropertyName("height")] public int Height { get; init; }
}
