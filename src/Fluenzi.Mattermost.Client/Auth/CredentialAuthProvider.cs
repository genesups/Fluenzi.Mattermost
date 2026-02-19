using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reactive.Subjects;
using System.Text.Json;
using Fluenzi.Mattermost.Constants;
using Fluenzi.Mattermost.Interfaces.Auth;
using Fluenzi.Mattermost.Models.Users;

namespace Fluenzi.Mattermost.Client.Auth;

public class CredentialAuthProvider : IAuthProvider, IDisposable
{
    private readonly HttpClient _httpClient;
    private readonly BehaviorSubject<AuthState> _authState = new(AuthState.NotAuthenticated);
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
    };

    private string? _token;
    private User? _currentUser;

    public string? CurrentToken => _token;
    public User? CurrentUser => _currentUser;
    public bool IsAuthenticated => _token != null && _authState.Value == AuthState.Authenticated;
    public IObservable<AuthState> AuthStateChanged => _authState;

    public CredentialAuthProvider(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<AuthResult> LoginWithTokenAsync(string token, CancellationToken ct = default)
    {
        _authState.OnNext(AuthState.Authenticating);
        _token = token;
        try
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, ApiRoutes.UsersMe);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var response = await _httpClient.SendAsync(request, ct);
            response.EnsureSuccessStatusCode();
            _currentUser = await response.Content.ReadFromJsonAsync<User>(JsonOptions, ct);
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

    public async Task<AuthResult> LoginWithCredentialsAsync(string loginId, string password, CancellationToken ct = default)
    {
        _authState.OnNext(AuthState.Authenticating);
        try
        {
            var body = new { login_id = loginId, password };
            using var response = await _httpClient.PostAsJsonAsync(ApiRoutes.UsersLogin, body, JsonOptions, ct);
            response.EnsureSuccessStatusCode();

            _token = response.Headers.TryGetValues("Token", out var tokens) ? tokens.FirstOrDefault() : null;
            _currentUser = await response.Content.ReadFromJsonAsync<User>(JsonOptions, ct);
            _authState.OnNext(AuthState.Authenticated);
            return new AuthResult(true, _currentUser, _token, null);
        }
        catch (Exception ex)
        {
            _token = null;
            _currentUser = null;
            _authState.OnNext(AuthState.NotAuthenticated);
            return new AuthResult(false, null, null, ex.Message);
        }
    }

    public async Task<AuthResult> LoginWithMfaAsync(string loginId, string password, string mfaToken, CancellationToken ct = default)
    {
        _authState.OnNext(AuthState.Authenticating);
        try
        {
            var body = new { login_id = loginId, password, token = mfaToken };
            using var response = await _httpClient.PostAsJsonAsync(ApiRoutes.UsersLogin, body, JsonOptions, ct);
            response.EnsureSuccessStatusCode();

            _token = response.Headers.TryGetValues("Token", out var tokens) ? tokens.FirstOrDefault() : null;
            _currentUser = await response.Content.ReadFromJsonAsync<User>(JsonOptions, ct);
            _authState.OnNext(AuthState.Authenticated);
            return new AuthResult(true, _currentUser, _token, null);
        }
        catch (Exception ex)
        {
            _token = null;
            _currentUser = null;
            _authState.OnNext(AuthState.NotAuthenticated);
            return new AuthResult(false, null, null, ex.Message);
        }
    }

    public async Task LogoutAsync(CancellationToken ct = default)
    {
        if (_token != null)
        {
            try
            {
                using var request = new HttpRequestMessage(HttpMethod.Post, ApiRoutes.UsersLogout);
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);
                await _httpClient.SendAsync(request, ct);
            }
            catch { /* Best effort logout */ }
        }
        _token = null;
        _currentUser = null;
        _authState.OnNext(AuthState.NotAuthenticated);
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
