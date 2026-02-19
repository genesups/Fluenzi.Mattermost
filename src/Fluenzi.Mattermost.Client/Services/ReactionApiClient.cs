using Fluenzi.Mattermost.Client.Internal;
using Fluenzi.Mattermost.Constants;
using Fluenzi.Mattermost.Interfaces.Client;
using Fluenzi.Mattermost.Models.Reactions;

namespace Fluenzi.Mattermost.Client.Services;

public class ReactionApiClient : IReactionApi
{
    private readonly ApiRequestHandler _api;

    public ReactionApiClient(ApiRequestHandler api) => _api = api;

    public Task<Reaction> SaveReactionAsync(Reaction reaction, CancellationToken ct = default)
        => _api.PostAsync<Reaction>(ApiRoutes.Reactions, reaction, ct);

    public async Task DeleteReactionAsync(string userId, string postId, string emojiName, CancellationToken ct = default)
        => await _api.DeleteAsync($"{ApiRoutes.Users}/{userId}/posts/{postId}/reactions/{emojiName}", ct);

    public Task<IReadOnlyList<Reaction>> GetReactionsAsync(string postId, CancellationToken ct = default)
        => _api.GetAsync<IReadOnlyList<Reaction>>(string.Format(ApiRoutes.PostReactions, postId), ct);
}
