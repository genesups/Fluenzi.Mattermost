using Fluenzi.Mattermost.Models.Reactions;

namespace Fluenzi.Mattermost.Interfaces.Client;

public interface IReactionApi
{
    Task<Reaction> SaveReactionAsync(Reaction reaction, CancellationToken ct = default);
    Task DeleteReactionAsync(string userId, string postId, string emojiName, CancellationToken ct = default);
    Task<IReadOnlyList<Reaction>> GetReactionsAsync(string postId, CancellationToken ct = default);
}
