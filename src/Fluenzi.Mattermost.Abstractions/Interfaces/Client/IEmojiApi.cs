using Fluenzi.Mattermost.Models.Emoji;
using Fluenzi.Mattermost.Models.Common;

namespace Fluenzi.Mattermost.Interfaces.Client;

public interface IEmojiApi
{
    Task<PagedResult<CustomEmoji>> GetCustomEmojisAsync(int page = 0, int perPage = 60, string? sort = null, CancellationToken ct = default);
    Task<CustomEmoji> CreateCustomEmojiAsync(string name, Stream image, CancellationToken ct = default);
    Task DeleteCustomEmojiAsync(string emojiId, CancellationToken ct = default);
    Task<CustomEmoji> GetCustomEmojiAsync(string emojiId, CancellationToken ct = default);
    Task<CustomEmoji> GetCustomEmojiByNameAsync(string name, CancellationToken ct = default);
    Task<byte[]> GetCustomEmojiImageAsync(string emojiId, CancellationToken ct = default);
    Task<IReadOnlyList<CustomEmoji>> SearchCustomEmojisAsync(string term, CancellationToken ct = default);
    Task<IReadOnlyList<CustomEmoji>> AutocompleteCustomEmojisAsync(string name, CancellationToken ct = default);
}
