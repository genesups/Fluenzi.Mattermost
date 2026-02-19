using System.Runtime.CompilerServices;
using Fluenzi.Mattermost.Client.Internal;
using Fluenzi.Mattermost.Constants;
using Fluenzi.Mattermost.Interfaces.Client;
using Fluenzi.Mattermost.Models.Common;
using Fluenzi.Mattermost.Models.Users;

namespace Fluenzi.Mattermost.Client.Services;

public class UserApiClient : IUserApi
{
    private readonly ApiRequestHandler _api;

    public UserApiClient(ApiRequestHandler api) => _api = api;

    public Task<User> GetMeAsync(CancellationToken ct = default)
        => _api.GetAsync<User>(ApiRoutes.UsersMe, ct);

    public Task<User> GetUserAsync(string userId, CancellationToken ct = default)
        => _api.GetAsync<User>(string.Format(ApiRoutes.User, userId), ct);

    public Task<User> GetUserByUsernameAsync(string username, CancellationToken ct = default)
        => _api.GetAsync<User>(string.Format(ApiRoutes.UserByUsername, username), ct);

    public Task<User> GetUserByEmailAsync(string email, CancellationToken ct = default)
        => _api.GetAsync<User>(string.Format(ApiRoutes.UserByEmail, email), ct);

    public Task<PagedResult<User>> GetUsersAsync(int page = 0, int perPage = 60, CancellationToken ct = default)
        => _api.GetPagedAsync<User>(ApiRoutes.Users, page, perPage, ct);

    public IAsyncEnumerable<User> GetAllUsersAsync(CancellationToken ct = default)
        => _api.GetAllPagesAsync<User>(ApiRoutes.Users, ct: ct);

    public Task<IReadOnlyList<User>> GetUsersByIdsAsync(IEnumerable<string> userIds, CancellationToken ct = default)
        => _api.PostAsync<IReadOnlyList<User>>($"{ApiRoutes.Users}/ids", userIds.ToArray(), ct);

    public Task<IReadOnlyList<User>> GetUsersByUsernamesAsync(IEnumerable<string> usernames, CancellationToken ct = default)
        => _api.PostAsync<IReadOnlyList<User>>($"{ApiRoutes.Users}/usernames", usernames.ToArray(), ct);

    public Task<IReadOnlyList<User>> SearchUsersAsync(string term, CancellationToken ct = default)
        => _api.PostAsync<IReadOnlyList<User>>(ApiRoutes.UsersSearch, new { term }, ct);

    public Task<User> UpdateUserAsync(string userId, User user, CancellationToken ct = default)
        => _api.PutAsync<User>(string.Format(ApiRoutes.User, userId), user, ct);

    public Task<User> PatchUserAsync(string userId, Dictionary<string, object> patch, CancellationToken ct = default)
        => _api.PutAsync<User>(string.Format(ApiRoutes.UserPatch, userId), patch, ct);

    public Task<UserStatus> GetUserStatusAsync(string userId, CancellationToken ct = default)
        => _api.GetAsync<UserStatus>(string.Format(ApiRoutes.UserStatus, userId), ct);

    public Task<IReadOnlyList<UserStatus>> GetUsersStatusByIdsAsync(IEnumerable<string> userIds, CancellationToken ct = default)
        => _api.PostAsync<IReadOnlyList<UserStatus>>(ApiRoutes.UsersStatus, userIds.ToArray(), ct);

    public Task<UserStatus> UpdateUserStatusAsync(string userId, UserStatus status, CancellationToken ct = default)
        => _api.PutAsync<UserStatus>(string.Format(ApiRoutes.UserStatus, userId), status, ct);

    public Task<byte[]?> GetProfileImageAsync(string userId, CancellationToken ct = default)
        => _api.GetBytesAsync(string.Format(ApiRoutes.UserImage, userId), ct)!;

    public async Task SetProfileImageAsync(string userId, Stream image, CancellationToken ct = default)
    {
        using var content = new MultipartFormDataContent();
        content.Add(new StreamContent(image), "image", "profile.png");
        await _api.PostMultipartAsync(string.Format(ApiRoutes.UserImage, userId), content, ct);
    }

    public async Task<IReadOnlyList<UserAccessToken>> GetUserAccessTokensAsync(string userId, int page = 0, int perPage = 60, CancellationToken ct = default)
    {
        var result = await _api.GetPagedAsync<UserAccessToken>(string.Format(ApiRoutes.UserTokens, userId), page, perPage, ct);
        return result.Items;
    }

    public Task<UserAccessToken> CreateUserAccessTokenAsync(string userId, string description, CancellationToken ct = default)
        => _api.PostAsync<UserAccessToken>(string.Format(ApiRoutes.UserTokens, userId), new { description }, ct);

    public async Task RevokeUserAccessTokenAsync(string tokenId, CancellationToken ct = default)
        => await _api.PostAsync($"{ApiRoutes.Users}/tokens/revoke", new { token_id = tokenId }, ct);

    public Task<IReadOnlyList<Session>> GetUserSessionsAsync(string userId, CancellationToken ct = default)
        => _api.GetAsync<IReadOnlyList<Session>>(string.Format(ApiRoutes.UserSessions, userId), ct);

    public async Task RevokeSessionAsync(string userId, string sessionId, CancellationToken ct = default)
        => await _api.PostAsync($"{string.Format(ApiRoutes.UserSessions, userId)}/revoke", new { session_id = sessionId }, ct);

    public async Task DeactivateUserAsync(string userId, CancellationToken ct = default)
        => await _api.DeleteAsync(string.Format(ApiRoutes.User, userId), ct);

    public Task<UserCustomStatus?> GetUserCustomStatusAsync(string userId, CancellationToken ct = default)
        => _api.GetAsync<UserCustomStatus?>(string.Format(ApiRoutes.User, userId) + "/status/custom", ct);

    public async Task UpdateUserCustomStatusAsync(string userId, UserCustomStatus status, CancellationToken ct = default)
        => await _api.PutAsync(string.Format(ApiRoutes.User, userId) + "/status/custom", status, ct);

    public async Task RemoveUserCustomStatusAsync(string userId, CancellationToken ct = default)
        => await _api.DeleteAsync(string.Format(ApiRoutes.User, userId) + "/status/custom", ct);
}
