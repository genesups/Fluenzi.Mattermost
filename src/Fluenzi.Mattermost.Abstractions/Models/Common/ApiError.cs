using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Common;

/// <summary>
/// Represents an error response from the Mattermost API.
/// </summary>
public record ApiError
{
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [JsonPropertyName("message")]
    public string? Message { get; init; }

    [JsonPropertyName("detailed_error")]
    public string? DetailedError { get; init; }

    [JsonPropertyName("request_id")]
    public string? RequestId { get; init; }

    [JsonPropertyName("status_code")]
    public int StatusCode { get; init; }

    [JsonPropertyName("is_oauth")]
    public bool IsOAuth { get; init; }
}
