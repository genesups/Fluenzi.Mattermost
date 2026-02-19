using Fluenzi.Mattermost.Models.Threads;

namespace Fluenzi.Mattermost.Interfaces.Client;

public interface IThreadApi
{
    Task<ThreadResponse> GetUserThreadsAsync(string userId, string teamId, int page = 0, int perPage = 25, bool extended = false, bool deleted = false, long? since = null, CancellationToken ct = default);
    Task<UserThread> GetUserThreadAsync(string userId, string teamId, string threadId, CancellationToken ct = default);
    Task FollowThreadAsync(string userId, string teamId, string threadId, CancellationToken ct = default);
    Task UnfollowThreadAsync(string userId, string teamId, string threadId, CancellationToken ct = default);
    Task MarkThreadAsReadAsync(string userId, string teamId, string threadId, long timestamp, CancellationToken ct = default);
    Task MarkAllThreadsAsReadAsync(string userId, string teamId, CancellationToken ct = default);
}
