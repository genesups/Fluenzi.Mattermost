using Fluenzi.Mattermost.Models.Posts;

namespace Fluenzi.Mattermost.Interfaces.Client;

public interface IPostApi
{
    Task<Post> CreatePostAsync(Post post, CancellationToken ct = default);
    Task<Post> GetPostAsync(string postId, CancellationToken ct = default);
    Task<Post> UpdatePostAsync(string postId, Post post, CancellationToken ct = default);
    Task<Post> PatchPostAsync(string postId, Dictionary<string, object> patch, CancellationToken ct = default);
    Task DeletePostAsync(string postId, CancellationToken ct = default);
    Task<PostList> GetChannelPostsAsync(string channelId, int page = 0, int perPage = 60, string? before = null, string? after = null, bool includeDeleted = false, long? since = null, CancellationToken ct = default);
    Task<PostList> GetPostThreadAsync(string postId, string? fromPost = null, bool fromCreateAt = false, int perPage = 60, CancellationToken ct = default);
    Task PinPostAsync(string postId, CancellationToken ct = default);
    Task UnpinPostAsync(string postId, CancellationToken ct = default);
    Task<PostList> SearchPostsAsync(string teamId, string terms, bool isOrSearch = false, CancellationToken ct = default);
    Task<PostList> GetFlaggedPostsAsync(string userId, int page = 0, int perPage = 60, string? channelId = null, string? teamId = null, CancellationToken ct = default);
    Task<Post> DoPostActionAsync(string postId, string actionId, CancellationToken ct = default);
    Task AcknowledgePostAsync(string postId, CancellationToken ct = default);
    Task UnacknowledgePostAsync(string postId, CancellationToken ct = default);
}
