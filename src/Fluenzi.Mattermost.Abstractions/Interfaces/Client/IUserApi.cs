using Fluenzi.Mattermost.Models.Users;
using Fluenzi.Mattermost.Models.Common;

namespace Fluenzi.Mattermost.Interfaces.Client;

public interface IUserApi
{
    Task<User> GetMeAsync(CancellationToken ct = default);
    Task<User> GetUserAsync(string userId, CancellationToken ct = default);
    Task<User> GetUserByUsernameAsync(string username, CancellationToken ct = default);
    Task<User> GetUserByEmailAsync(string email, CancellationToken ct = default);
    Task<PagedResult<User>> GetUsersAsync(int page = 0, int perPage = 60, CancellationToken ct = default);
    IAsyncEnumerable<User> GetAllUsersAsync(CancellationToken ct = default);
    Task<IReadOnlyList<User>> GetUsersByIdsAsync(IEnumerable<string> userIds, CancellationToken ct = default);
    Task<IReadOnlyList<User>> GetUsersByUsernamesAsync(IEnumerable<string> usernames, CancellationToken ct = default);
    Task<IReadOnlyList<User>> SearchUsersAsync(string term, CancellationToken ct = default);
    Task<User> UpdateUserAsync(string userId, User user, CancellationToken ct = default);
    Task<User> PatchUserAsync(string userId, Dictionary<string, object> patch, CancellationToken ct = default);
    Task<UserStatus> GetUserStatusAsync(string userId, CancellationToken ct = default);
    Task<IReadOnlyList<UserStatus>> GetUsersStatusByIdsAsync(IEnumerable<string> userIds, CancellationToken ct = default);
    Task<UserStatus> UpdateUserStatusAsync(string userId, UserStatus status, CancellationToken ct = default);
    Task<byte[]?> GetProfileImageAsync(string userId, CancellationToken ct = default);
    Task SetProfileImageAsync(string userId, Stream image, CancellationToken ct = default);
    Task<IReadOnlyList<UserAccessToken>> GetUserAccessTokensAsync(string userId, int page = 0, int perPage = 60, CancellationToken ct = default);
    Task<UserAccessToken> CreateUserAccessTokenAsync(string userId, string description, CancellationToken ct = default);
    Task RevokeUserAccessTokenAsync(string tokenId, CancellationToken ct = default);
    Task<IReadOnlyList<Session>> GetUserSessionsAsync(string userId, CancellationToken ct = default);
    Task RevokeSessionAsync(string userId, string sessionId, CancellationToken ct = default);
    Task DeactivateUserAsync(string userId, CancellationToken ct = default);
    Task<UserCustomStatus?> GetUserCustomStatusAsync(string userId, CancellationToken ct = default);
    Task UpdateUserCustomStatusAsync(string userId, UserCustomStatus status, CancellationToken ct = default);
    Task RemoveUserCustomStatusAsync(string userId, CancellationToken ct = default);
}
