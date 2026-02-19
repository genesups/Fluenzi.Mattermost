using Fluenzi.Mattermost.Models.Webhooks;
using Fluenzi.Mattermost.Models.Common;

namespace Fluenzi.Mattermost.Interfaces.Client;

public interface IWebhookApi
{
    Task<IncomingWebhook> CreateIncomingWebhookAsync(IncomingWebhook webhook, CancellationToken ct = default);
    Task<PagedResult<IncomingWebhook>> GetIncomingWebhooksAsync(string? teamId = null, int page = 0, int perPage = 60, CancellationToken ct = default);
    Task<IncomingWebhook> GetIncomingWebhookAsync(string hookId, CancellationToken ct = default);
    Task<IncomingWebhook> UpdateIncomingWebhookAsync(string hookId, IncomingWebhook webhook, CancellationToken ct = default);
    Task DeleteIncomingWebhookAsync(string hookId, CancellationToken ct = default);
    Task<OutgoingWebhook> CreateOutgoingWebhookAsync(OutgoingWebhook webhook, CancellationToken ct = default);
    Task<PagedResult<OutgoingWebhook>> GetOutgoingWebhooksAsync(string? teamId = null, string? channelId = null, int page = 0, int perPage = 60, CancellationToken ct = default);
    Task<OutgoingWebhook> GetOutgoingWebhookAsync(string hookId, CancellationToken ct = default);
    Task<OutgoingWebhook> UpdateOutgoingWebhookAsync(string hookId, OutgoingWebhook webhook, CancellationToken ct = default);
    Task DeleteOutgoingWebhookAsync(string hookId, CancellationToken ct = default);
    Task<OutgoingWebhook> RegenOutgoingWebhookTokenAsync(string hookId, CancellationToken ct = default);
}
