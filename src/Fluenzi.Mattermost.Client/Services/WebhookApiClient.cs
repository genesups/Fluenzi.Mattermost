using Fluenzi.Mattermost.Client.Internal;
using Fluenzi.Mattermost.Constants;
using Fluenzi.Mattermost.Interfaces.Client;
using Fluenzi.Mattermost.Models.Common;
using Fluenzi.Mattermost.Models.Webhooks;

namespace Fluenzi.Mattermost.Client.Services;

public class WebhookApiClient : IWebhookApi
{
    private readonly ApiRequestHandler _api;
    public WebhookApiClient(ApiRequestHandler api) => _api = api;

    public Task<IncomingWebhook> CreateIncomingWebhookAsync(IncomingWebhook webhook, CancellationToken ct = default)
        => _api.PostAsync<IncomingWebhook>(ApiRoutes.IncomingWebhooks, webhook, ct);

    public Task<PagedResult<IncomingWebhook>> GetIncomingWebhooksAsync(string? teamId = null, int page = 0, int perPage = 60, CancellationToken ct = default)
    {
        var url = ApiRoutes.IncomingWebhooks;
        if (teamId != null) url += $"?team_id={teamId}";
        return _api.GetPagedAsync<IncomingWebhook>(url, page, perPage, ct);
    }

    public Task<IncomingWebhook> GetIncomingWebhookAsync(string hookId, CancellationToken ct = default)
        => _api.GetAsync<IncomingWebhook>(string.Format(ApiRoutes.IncomingWebhook, hookId), ct);

    public Task<IncomingWebhook> UpdateIncomingWebhookAsync(string hookId, IncomingWebhook webhook, CancellationToken ct = default)
        => _api.PutAsync<IncomingWebhook>(string.Format(ApiRoutes.IncomingWebhook, hookId), webhook, ct);

    public async Task DeleteIncomingWebhookAsync(string hookId, CancellationToken ct = default)
        => await _api.DeleteAsync(string.Format(ApiRoutes.IncomingWebhook, hookId), ct);

    public Task<OutgoingWebhook> CreateOutgoingWebhookAsync(OutgoingWebhook webhook, CancellationToken ct = default)
        => _api.PostAsync<OutgoingWebhook>(ApiRoutes.OutgoingWebhooks, webhook, ct);

    public Task<PagedResult<OutgoingWebhook>> GetOutgoingWebhooksAsync(string? teamId = null, string? channelId = null, int page = 0, int perPage = 60, CancellationToken ct = default)
    {
        var url = ApiRoutes.OutgoingWebhooks;
        var sep = '?';
        if (teamId != null) { url += $"{sep}team_id={teamId}"; sep = '&'; }
        if (channelId != null) { url += $"{sep}channel_id={channelId}"; }
        return _api.GetPagedAsync<OutgoingWebhook>(url, page, perPage, ct);
    }

    public Task<OutgoingWebhook> GetOutgoingWebhookAsync(string hookId, CancellationToken ct = default)
        => _api.GetAsync<OutgoingWebhook>(string.Format(ApiRoutes.OutgoingWebhook, hookId), ct);

    public Task<OutgoingWebhook> UpdateOutgoingWebhookAsync(string hookId, OutgoingWebhook webhook, CancellationToken ct = default)
        => _api.PutAsync<OutgoingWebhook>(string.Format(ApiRoutes.OutgoingWebhook, hookId), webhook, ct);

    public async Task DeleteOutgoingWebhookAsync(string hookId, CancellationToken ct = default)
        => await _api.DeleteAsync(string.Format(ApiRoutes.OutgoingWebhook, hookId), ct);

    public Task<OutgoingWebhook> RegenOutgoingWebhookTokenAsync(string hookId, CancellationToken ct = default)
        => _api.PostAsync<OutgoingWebhook>(string.Format(ApiRoutes.OutgoingWebhookRegen, hookId), ct: ct);
}
