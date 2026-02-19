using Fluenzi.Mattermost.Client.Internal;
using Fluenzi.Mattermost.Constants;
using Fluenzi.Mattermost.Interfaces.Client;
using Fluenzi.Mattermost.Models.Commands;

namespace Fluenzi.Mattermost.Client.Services;

public class CommandApiClient : ICommandApi
{
    private readonly ApiRequestHandler _api;
    public CommandApiClient(ApiRequestHandler api) => _api = api;

    public Task<CommandResponse> ExecuteCommandAsync(string channelId, string command, CancellationToken ct = default)
        => _api.PostAsync<CommandResponse>(ApiRoutes.CommandExecute, new { channel_id = channelId, command }, ct);

    public Task<IReadOnlyList<SlashCommand>> ListCommandsAsync(string teamId, bool customOnly = false, CancellationToken ct = default)
        => _api.GetAsync<IReadOnlyList<SlashCommand>>($"{ApiRoutes.Commands}?team_id={teamId}&custom_only={customOnly.ToString().ToLower()}", ct);

    public Task<SlashCommand> CreateCommandAsync(SlashCommand command, CancellationToken ct = default)
        => _api.PostAsync<SlashCommand>(ApiRoutes.Commands, command, ct);

    public Task<SlashCommand> UpdateCommandAsync(string commandId, SlashCommand command, CancellationToken ct = default)
        => _api.PutAsync<SlashCommand>(string.Format(ApiRoutes.Command, commandId), command, ct);

    public async Task DeleteCommandAsync(string commandId, CancellationToken ct = default)
        => await _api.DeleteAsync(string.Format(ApiRoutes.Command, commandId), ct);
}
