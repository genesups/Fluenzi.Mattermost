using Fluenzi.Mattermost.Models.Integrations;
using Fluenzi.Mattermost.Models.Common;

namespace Fluenzi.Mattermost.Interfaces.Client;

public interface IBotApi
{
    Task<Bot> CreateBotAsync(Bot bot, CancellationToken ct = default);
    Task<Bot> GetBotAsync(string botUserId, CancellationToken ct = default);
    Task<PagedResult<Bot>> GetBotsAsync(int page = 0, int perPage = 60, bool includeDeleted = false, CancellationToken ct = default);
    Task<Bot> PatchBotAsync(string botUserId, BotPatch patch, CancellationToken ct = default);
    Task<Bot> DisableBotAsync(string botUserId, CancellationToken ct = default);
    Task<Bot> EnableBotAsync(string botUserId, CancellationToken ct = default);
    Task<Bot> AssignBotAsync(string botUserId, string newOwnerId, CancellationToken ct = default);
    Task<byte[]> GetBotIconAsync(string botUserId, CancellationToken ct = default);
    Task SetBotIconAsync(string botUserId, Stream icon, CancellationToken ct = default);
    Task DeleteBotIconAsync(string botUserId, CancellationToken ct = default);
}
