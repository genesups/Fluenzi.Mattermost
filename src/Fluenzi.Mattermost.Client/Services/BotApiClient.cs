using Fluenzi.Mattermost.Client.Internal;
using Fluenzi.Mattermost.Constants;
using Fluenzi.Mattermost.Interfaces.Client;
using Fluenzi.Mattermost.Models.Common;
using Fluenzi.Mattermost.Models.Integrations;

namespace Fluenzi.Mattermost.Client.Services;

public class BotApiClient : IBotApi
{
    private readonly ApiRequestHandler _api;
    public BotApiClient(ApiRequestHandler api) => _api = api;

    public Task<Bot> CreateBotAsync(Bot bot, CancellationToken ct = default)
        => _api.PostAsync<Bot>(ApiRoutes.Bots, bot, ct);

    public Task<Bot> GetBotAsync(string botUserId, CancellationToken ct = default)
        => _api.GetAsync<Bot>(string.Format(ApiRoutes.Bot, botUserId), ct);

    public Task<PagedResult<Bot>> GetBotsAsync(int page = 0, int perPage = 60, bool includeDeleted = false, CancellationToken ct = default)
        => _api.GetPagedAsync<Bot>($"{ApiRoutes.Bots}?include_deleted={includeDeleted.ToString().ToLower()}", page, perPage, ct);

    public Task<Bot> PatchBotAsync(string botUserId, BotPatch patch, CancellationToken ct = default)
        => _api.PutAsync<Bot>(string.Format(ApiRoutes.Bot, botUserId), patch, ct);

    public Task<Bot> DisableBotAsync(string botUserId, CancellationToken ct = default)
        => _api.PostAsync<Bot>(string.Format(ApiRoutes.BotDisable, botUserId), ct: ct);

    public Task<Bot> EnableBotAsync(string botUserId, CancellationToken ct = default)
        => _api.PostAsync<Bot>(string.Format(ApiRoutes.BotEnable, botUserId), ct: ct);

    public Task<Bot> AssignBotAsync(string botUserId, string newOwnerId, CancellationToken ct = default)
        => _api.PostAsync<Bot>(string.Format(ApiRoutes.BotAssign, botUserId, newOwnerId), ct: ct);

    public Task<byte[]> GetBotIconAsync(string botUserId, CancellationToken ct = default)
        => _api.GetBytesAsync(string.Format(ApiRoutes.BotIcon, botUserId), ct);

    public async Task SetBotIconAsync(string botUserId, Stream icon, CancellationToken ct = default)
    {
        using var content = new MultipartFormDataContent();
        content.Add(new StreamContent(icon), "image", "icon.png");
        await _api.PostMultipartAsync(string.Format(ApiRoutes.BotIcon, botUserId), content, ct);
    }

    public async Task DeleteBotIconAsync(string botUserId, CancellationToken ct = default)
        => await _api.DeleteAsync(string.Format(ApiRoutes.BotIcon, botUserId), ct);
}
