using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Fluenzi.Mattermost.Interfaces.Auth;
using Fluenzi.Mattermost.Models.Common;

namespace Fluenzi.Mattermost.Client.Internal;

public class ApiRequestHandler
{
    private readonly HttpClient _httpClient;
    private readonly IAuthProvider _authProvider;
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
    };

    public ApiRequestHandler(HttpClient httpClient, IAuthProvider authProvider)
    {
        _httpClient = httpClient;
        _authProvider = authProvider;
    }

    private void SetAuthHeader(HttpRequestMessage request)
    {
        var token = _authProvider.CurrentToken;
        if (!string.IsNullOrEmpty(token))
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }

    public async Task<T> GetAsync<T>(string path, CancellationToken ct = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, path);
        SetAuthHeader(request);
        return await SendAsync<T>(request, ct);
    }

    public async Task<T> PostAsync<T>(string path, object? body = null, CancellationToken ct = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, path);
        SetAuthHeader(request);
        if (body != null)
            request.Content = JsonContent.Create(body, options: JsonOptions);
        return await SendAsync<T>(request, ct);
    }

    public async Task PostAsync(string path, object? body = null, CancellationToken ct = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, path);
        SetAuthHeader(request);
        if (body != null)
            request.Content = JsonContent.Create(body, options: JsonOptions);
        await SendAsync(request, ct);
    }

    public async Task<T> PutAsync<T>(string path, object? body = null, CancellationToken ct = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Put, path);
        SetAuthHeader(request);
        if (body != null)
            request.Content = JsonContent.Create(body, options: JsonOptions);
        return await SendAsync<T>(request, ct);
    }

    public async Task PutAsync(string path, object? body = null, CancellationToken ct = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Put, path);
        SetAuthHeader(request);
        if (body != null)
            request.Content = JsonContent.Create(body, options: JsonOptions);
        await SendAsync(request, ct);
    }

    public async Task DeleteAsync(string path, CancellationToken ct = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Delete, path);
        SetAuthHeader(request);
        await SendAsync(request, ct);
    }

    public async Task<T> PatchAsync<T>(string path, object? body = null, CancellationToken ct = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Patch, path);
        SetAuthHeader(request);
        if (body != null)
            request.Content = JsonContent.Create(body, options: JsonOptions);
        return await SendAsync<T>(request, ct);
    }

    public async Task<byte[]> GetBytesAsync(string path, CancellationToken ct = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, path);
        SetAuthHeader(request);
        using var response = await _httpClient.SendAsync(request, ct);
        await EnsureSuccessAsync(response, ct);
        return await response.Content.ReadAsByteArrayAsync(ct);
    }

    public async Task<Stream> GetStreamAsync(string path, CancellationToken ct = default)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, path);
        SetAuthHeader(request);
        var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, ct);
        await EnsureSuccessAsync(response, ct);
        return await response.Content.ReadAsStreamAsync(ct);
    }

    public async Task<T> PostMultipartAsync<T>(string path, MultipartFormDataContent content, CancellationToken ct = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, path) { Content = content };
        SetAuthHeader(request);
        return await SendAsync<T>(request, ct);
    }

    public async Task PostMultipartAsync(string path, MultipartFormDataContent content, CancellationToken ct = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, path) { Content = content };
        SetAuthHeader(request);
        await SendAsync(request, ct);
    }

    public async Task<HttpResponseMessage> SendRawAsync(HttpRequestMessage request, CancellationToken ct = default)
    {
        SetAuthHeader(request);
        var response = await _httpClient.SendAsync(request, ct);
        await EnsureSuccessAsync(response, ct);
        return response;
    }

    public async Task<PagedResult<T>> GetPagedAsync<T>(string path, int page, int perPage, CancellationToken ct = default)
    {
        var separator = path.Contains('?') ? '&' : '?';
        var url = $"{path}{separator}page={page}&per_page={perPage}";
        var items = await GetAsync<List<T>>(url, ct);
        return new PagedResult<T>(items, items.Count >= perPage);
    }

    public async IAsyncEnumerable<T> GetAllPagesAsync<T>(string path, int perPage = 200, [EnumeratorCancellation] CancellationToken ct = default)
    {
        var page = 0;
        while (true)
        {
            var result = await GetPagedAsync<T>(path, page, perPage, ct);
            foreach (var item in result.Items)
                yield return item;
            if (!result.HasMore)
                break;
            page++;
        }
    }

    private async Task<T> SendAsync<T>(HttpRequestMessage request, CancellationToken ct)
    {
        using var response = await _httpClient.SendAsync(request, ct);
        await EnsureSuccessAsync(response, ct);
        var result = await response.Content.ReadFromJsonAsync<T>(JsonOptions, ct);
        return result ?? throw new InvalidOperationException("Deserialized response was null");
    }

    private async Task SendAsync(HttpRequestMessage request, CancellationToken ct)
    {
        using var response = await _httpClient.SendAsync(request, ct);
        await EnsureSuccessAsync(response, ct);
    }

    private static async Task EnsureSuccessAsync(HttpResponseMessage response, CancellationToken ct)
    {
        if (response.IsSuccessStatusCode)
            return;

        ApiError? error = null;
        try
        {
            error = await response.Content.ReadFromJsonAsync<ApiError>(JsonOptions, ct);
        }
        catch { /* Response body may not be valid JSON */ }

        if (error != null && !string.IsNullOrEmpty(error.Id))
        {
            throw new MattermostApiException(error, response.StatusCode, response.RequestMessage?.RequestUri, response.RequestMessage?.Method);
        }

        throw new MattermostApiException(
            $"HTTP {(int)response.StatusCode} {response.ReasonPhrase}",
            response.StatusCode,
            response.RequestMessage?.RequestUri,
            response.RequestMessage?.Method);
    }
}
