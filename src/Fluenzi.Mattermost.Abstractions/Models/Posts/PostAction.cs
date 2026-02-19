using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Posts;

/// <summary>
/// Represents an interactive action button or menu on a post attachment.
/// </summary>
public record PostAction
{
    [JsonPropertyName("id")]
    public string? Id { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("data_source")]
    public string? DataSource { get; init; }

    [JsonPropertyName("style")]
    public string? Style { get; init; }

    [JsonPropertyName("integration")]
    public PostActionIntegration? Integration { get; init; }

    [JsonPropertyName("options")]
    public PostActionOption[]? Options { get; init; }

    [JsonPropertyName("default_option")]
    public string? DefaultOption { get; init; }

    [JsonPropertyName("cookie")]
    public string? Cookie { get; init; }

    [JsonPropertyName("disabled")]
    public bool Disabled { get; init; }
}
