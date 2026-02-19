using System.Text.Json.Serialization;
using Fluenzi.Mattermost.Models.Emoji;
using Fluenzi.Mattermost.Models.Files;
using Fluenzi.Mattermost.Models.Reactions;

namespace Fluenzi.Mattermost.Models.Posts;

/// <summary>
/// Metadata associated with a post.
/// </summary>
public record PostMetadata
{
    [JsonPropertyName("embeds")]
    public PostEmbed[]? Embeds { get; init; }

    [JsonPropertyName("emojis")]
    public CustomEmoji[]? Emojis { get; init; }

    [JsonPropertyName("files")]
    public Fluenzi.Mattermost.Models.Files.FileInfo[]? Files { get; init; }

    [JsonPropertyName("images")]
    public Dictionary<string, PostImage>? Images { get; init; }

    [JsonPropertyName("reactions")]
    public Reaction[]? Reactions { get; init; }

    [JsonPropertyName("acknowledgements")]
    public PostAcknowledgement[]? Acknowledgements { get; init; }

    [JsonPropertyName("priority")]
    public Dictionary<string, object>? Priority { get; init; }
}
