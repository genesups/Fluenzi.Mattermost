using Fluenzi.Mattermost.Models.Commands;

namespace Fluenzi.Mattermost.Interfaces.Client;

public interface ICommandApi
{
    Task<CommandResponse> ExecuteCommandAsync(string channelId, string command, CancellationToken ct = default);
    Task<IReadOnlyList<SlashCommand>> ListCommandsAsync(string teamId, bool customOnly = false, CancellationToken ct = default);
    Task<SlashCommand> CreateCommandAsync(SlashCommand command, CancellationToken ct = default);
    Task<SlashCommand> UpdateCommandAsync(string commandId, SlashCommand command, CancellationToken ct = default);
    Task DeleteCommandAsync(string commandId, CancellationToken ct = default);
}
