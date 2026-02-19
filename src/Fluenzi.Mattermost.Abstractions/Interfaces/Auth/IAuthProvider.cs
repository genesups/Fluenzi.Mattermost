using Fluenzi.Mattermost.Models.Users;

namespace Fluenzi.Mattermost.Interfaces.Auth;

public record AuthResult(bool Success, User? User, string? Token, string? Error);

public enum AuthState { NotAuthenticated, Authenticating, Authenticated, Expired }

public interface IAuthProvider
{
    string? CurrentToken { get; }
    User? CurrentUser { get; }
    bool IsAuthenticated { get; }
    IObservable<AuthState> AuthStateChanged { get; }
    Task<AuthResult> LoginWithTokenAsync(string token, CancellationToken ct = default);
    Task<AuthResult> LoginWithCredentialsAsync(string loginId, string password, CancellationToken ct = default);
    Task<AuthResult> LoginWithMfaAsync(string loginId, string password, string mfaToken, CancellationToken ct = default);
    Task LogoutAsync(CancellationToken ct = default);
    void SetToken(string token);
}
