using System.Reactive.Subjects;
using Fluenzi.Mattermost.Interfaces.Auth;
using Fluenzi.Mattermost.Models.Users;

namespace Fluenzi.Mattermost.Client.Auth;

public class TokenAuthProvider : IAuthProvider, IDisposable
{
    private readonly BehaviorSubject<AuthState> _authState = new(AuthState.NotAuthenticated);
    private string? _token;
    private User? _currentUser;
    private Func<string, CancellationToken, Task<User>>? _getMeFunc;

    public string? CurrentToken => _token;
    public User? CurrentUser => _currentUser;
    public bool IsAuthenticated => _token != null && _authState.Value == AuthState.Authenticated;
    public IObservable<AuthState> AuthStateChanged => _authState;

    internal void SetGetMeFunc(Func<string, CancellationToken, Task<User>> getMe)
    {
        _getMeFunc = getMe;
    }

    public async Task<AuthResult> LoginWithTokenAsync(string token, CancellationToken ct = default)
    {
        _authState.OnNext(AuthState.Authenticating);
        _token = token;
        try
        {
            if (_getMeFunc != null)
                _currentUser = await _getMeFunc(token, ct);
            _authState.OnNext(AuthState.Authenticated);
            return new AuthResult(true, _currentUser, token, null);
        }
        catch (Exception ex)
        {
            _token = null;
            _currentUser = null;
            _authState.OnNext(AuthState.NotAuthenticated);
            return new AuthResult(false, null, null, ex.Message);
        }
    }

    public Task<AuthResult> LoginWithCredentialsAsync(string loginId, string password, CancellationToken ct = default)
    {
        throw new NotSupportedException("TokenAuthProvider does not support credential-based login. Use CredentialAuthProvider instead.");
    }

    public Task<AuthResult> LoginWithMfaAsync(string loginId, string password, string mfaToken, CancellationToken ct = default)
    {
        throw new NotSupportedException("TokenAuthProvider does not support MFA login. Use CredentialAuthProvider instead.");
    }

    public Task LogoutAsync(CancellationToken ct = default)
    {
        _token = null;
        _currentUser = null;
        _authState.OnNext(AuthState.NotAuthenticated);
        return Task.CompletedTask;
    }

    public void SetToken(string token)
    {
        _token = token;
        _authState.OnNext(AuthState.Authenticated);
    }

    public void Dispose()
    {
        _authState.Dispose();
    }
}
