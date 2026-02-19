using Fluenzi.Mattermost.Client.Internal;
using Fluenzi.Mattermost.Constants;
using Fluenzi.Mattermost.Interfaces.Client;
using Fluenzi.Mattermost.Models.Common;
using Fluenzi.Mattermost.Models.Emoji;

namespace Fluenzi.Mattermost.Client.Services;

public class EmojiApiClient : IEmojiApi
{
    private readonly ApiRequestHandler _api;

    public EmojiApiClient(ApiRequestHandler api) => _api = api;

    public Task<PagedResult<CustomEmoji>> GetCustomEmojisAsync(int page = 0, int perPage = 60, string? sort = null, CancellationToken ct = default)
    {
        var url = ApiRoutes.Emojis;
        if (sort != null) url += $"?sort={sort}";
        return _api.GetPagedAsync<CustomEmoji>(url, page, perPage, ct);
    }

    public async Task<CustomEmoji> CreateCustomEmojiAsync(string name, Stream image, CancellationToken ct = default)
    {
        using var content = new MultipartFormDataContent();
        content.Add(new StringContent($"{{\"name\":\"{name}\"}}"), "emoji");
        content.Add(new StreamContent(image), "image", "emoji.png");
        return await _api.PostMultipartAsync<CustomEmoji>(ApiRoutes.Emojis, content, ct);
    }

    public async Task DeleteCustomEmojiAsync(string emojiId, CancellationToken ct = default)
        => await _api.DeleteAsync(string.Format(ApiRoutes.Emoji, emojiId), ct);

    public Task<CustomEmoji> GetCustomEmojiAsync(string emojiId, CancellationToken ct = default)
        => _api.GetAsync<CustomEmoji>(string.Format(ApiRoutes.Emoji, emojiId), ct);

    public Task<CustomEmoji> GetCustomEmojiByNameAsync(string name, CancellationToken ct = default)
        => _api.GetAsync<CustomEmoji>(string.Format(ApiRoutes.EmojiByName, name), ct);

    public Task<byte[]> GetCustomEmojiImageAsync(string emojiId, CancellationToken ct = default)
        => _api.GetBytesAsync(string.Format(ApiRoutes.EmojiImage, emojiId), ct);

    public Task<IReadOnlyList<CustomEmoji>> SearchCustomEmojisAsync(string term, CancellationToken ct = default)
        => _api.PostAsync<IReadOnlyList<CustomEmoji>>(ApiRoutes.EmojisSearch, new { term }, ct);

    public Task<IReadOnlyList<CustomEmoji>> AutocompleteCustomEmojisAsync(string name, CancellationToken ct = default)
        => _api.GetAsync<IReadOnlyList<CustomEmoji>>($"{ApiRoutes.EmojisAutocomplete}?name={name}", ct);
}
