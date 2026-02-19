using System.Text.Json.Serialization;

namespace Fluenzi.Mattermost.Models.Integrations;

/// <summary>
/// Represents a patch/update request for a bot account.
/// </summary>
public record BotPatch
{
    [JsonPropertyName("username")]
    public string? Username { get; init; }

    [JsonPropertyName("display_name")]
    public string? DisplayName { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }
}
