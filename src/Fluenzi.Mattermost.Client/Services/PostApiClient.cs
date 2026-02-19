using Fluenzi.Mattermost.Client.Internal;
using Fluenzi.Mattermost.Constants;
using Fluenzi.Mattermost.Interfaces.Client;
using Fluenzi.Mattermost.Models.Posts;

namespace Fluenzi.Mattermost.Client.Services;

public class PostApiClient : IPostApi
{
    private readonly ApiRequestHandler _api;

    public PostApiClient(ApiRequestHandler api) => _api = api;

    public Task<Post> CreatePostAsync(Post post, CancellationToken ct = default)
        => _api.PostAsync<Post>(ApiRoutes.Posts, post, ct);

    public Task<Post> GetPostAsync(string postId, CancellationToken ct = default)
        => _api.GetAsync<Post>(string.Format(ApiRoutes.Post, postId), ct);

    public Task<Post> UpdatePostAsync(string postId, Post post, CancellationToken ct = default)
        => _api.PutAsync<Post>(string.Format(ApiRoutes.Post, postId), post, ct);

    public Task<Post> PatchPostAsync(string postId, Dictionary<string, object> patch, CancellationToken ct = default)
        => _api.PutAsync<Post>(string.Format(ApiRoutes.PostPatch, postId), patch, ct);

    public async Task DeletePostAsync(string postId, CancellationToken ct = default)
        => await _api.DeleteAsync(string.Format(ApiRoutes.Post, postId), ct);

    public Task<PostList> GetChannelPostsAsync(string channelId, int page = 0, int perPage = 60, string? before = null, string? after = null, bool includeDeleted = false, long? since = null, CancellationToken ct = default)
    {
        var url = $"{string.Format(ApiRoutes.ChannelPosts, channelId)}?page={page}&per_page={perPage}";
        if (before != null) url += $"&before={before}";
        if (after != null) url += $"&after={after}";
        if (includeDeleted) url += "&include_deleted=true";
        if (since.HasValue) url += $"&since={since.Value}";
        return _api.GetAsync<PostList>(url, ct);
    }

    public Task<PostList> GetPostThreadAsync(string postId, string? fromPost = null, bool fromCreateAt = false, int perPage = 60, CancellationToken ct = default)
    {
        var url = $"{string.Format(ApiRoutes.PostThread, postId)}?per_page={perPage}";
        if (fromPost != null) url += $"&fromPost={fromPost}";
        if (fromCreateAt) url += "&fromCreateAt=true";
        return _api.GetAsync<PostList>(url, ct);
    }

    public async Task PinPostAsync(string postId, CancellationToken ct = default)
        => await _api.PostAsync(string.Format(ApiRoutes.PostPin, postId), ct: ct);

    public async Task UnpinPostAsync(string postId, CancellationToken ct = default)
        => await _api.PostAsync(string.Format(ApiRoutes.PostUnpin, postId), ct: ct);

    public Task<PostList> SearchPostsAsync(string teamId, string terms, bool isOrSearch = false, CancellationToken ct = default)
        => _api.PostAsync<PostList>(string.Format(ApiRoutes.PostsSearch, teamId), new { terms, is_or_search = isOrSearch }, ct);

    public Task<PostList> GetFlaggedPostsAsync(string userId, int page = 0, int perPage = 60, string? channelId = null, string? teamId = null, CancellationToken ct = default)
    {
        var url = $"{ApiRoutes.PostsFlagged}?page={page}&per_page={perPage}";
        if (channelId != null) url += $"&channel_id={channelId}";
        if (teamId != null) url += $"&team_id={teamId}";
        return _api.GetAsync<PostList>(url, ct);
    }

    public Task<Post> DoPostActionAsync(string postId, string actionId, CancellationToken ct = default)
        => _api.PostAsync<Post>(string.Format(ApiRoutes.PostActions, postId, actionId), ct: ct);

    public async Task AcknowledgePostAsync(string postId, CancellationToken ct = default)
        => await _api.PostAsync(string.Format(ApiRoutes.PostAcknowledge, postId), ct: ct);

    public async Task UnacknowledgePostAsync(string postId, CancellationToken ct = default)
        => await _api.PostAsync(string.Format(ApiRoutes.PostUnacknowledge, postId), ct: ct);
}
