using Fluenzi.Mattermost.Client.Internal;
using Fluenzi.Mattermost.Constants;
using Fluenzi.Mattermost.Interfaces.Client;
using Fluenzi.Mattermost.Models.Threads;

namespace Fluenzi.Mattermost.Client.Services;

public class ThreadApiClient : IThreadApi
{
    private readonly ApiRequestHandler _api;
    public ThreadApiClient(ApiRequestHandler api) => _api = api;

    public Task<ThreadResponse> GetUserThreadsAsync(string userId, string teamId, int page = 0, int perPage = 25, bool extended = false, bool deleted = false, long? since = null, CancellationToken ct = default)
    {
        var url = $"{string.Format(ApiRoutes.UserThreads, userId, teamId)}?page={page}&per_page={perPage}&extended={extended.ToString().ToLower()}&deleted={deleted.ToString().ToLower()}";
        if (since.HasValue) url += $"&since={since.Value}";
        return _api.GetAsync<ThreadResponse>(url, ct);
    }

    public Task<UserThread> GetUserThreadAsync(string userId, string teamId, string threadId, CancellationToken ct = default)
        => _api.GetAsync<UserThread>(string.Format(ApiRoutes.UserThread, userId, teamId, threadId), ct);

    public async Task FollowThreadAsync(string userId, string teamId, string threadId, CancellationToken ct = default)
        => await _api.PutAsync(string.Format(ApiRoutes.UserThreadFollowing, userId, teamId, threadId), ct: ct);

    public async Task UnfollowThreadAsync(string userId, string teamId, string threadId, CancellationToken ct = default)
        => await _api.DeleteAsync(string.Format(ApiRoutes.UserThreadFollowing, userId, teamId, threadId), ct);

    public async Task MarkThreadAsReadAsync(string userId, string teamId, string threadId, long timestamp, CancellationToken ct = default)
        => await _api.PutAsync(string.Format(ApiRoutes.UserThreadRead, userId, teamId, threadId, timestamp), ct: ct);

    public async Task MarkAllThreadsAsReadAsync(string userId, string teamId, CancellationToken ct = default)
        => await _api.PutAsync(string.Format(ApiRoutes.UserThreadsRead, userId, teamId), ct: ct);
}
