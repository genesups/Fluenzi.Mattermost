using Fluenzi.Mattermost.Client.Internal;
using Fluenzi.Mattermost.Constants;
using Fluenzi.Mattermost.Interfaces.Client;
using Fluenzi.Mattermost.Models.Preferences;

namespace Fluenzi.Mattermost.Client.Services;

public class PreferenceApiClient : IPreferenceApi
{
    private readonly ApiRequestHandler _api;
    public PreferenceApiClient(ApiRequestHandler api) => _api = api;

    public Task<IReadOnlyList<Preference>> GetPreferencesAsync(string userId, CancellationToken ct = default)
        => _api.GetAsync<IReadOnlyList<Preference>>(string.Format(ApiRoutes.Preferences, userId), ct);

    public async Task SavePreferencesAsync(string userId, IEnumerable<Preference> preferences, CancellationToken ct = default)
        => await _api.PutAsync(string.Format(ApiRoutes.Preferences, userId), preferences.ToArray(), ct);

    public async Task DeletePreferencesAsync(string userId, IEnumerable<Preference> preferences, CancellationToken ct = default)
        => await _api.PostAsync(string.Format(ApiRoutes.PreferencesDelete, userId), preferences.ToArray(), ct);

    public Task<IReadOnlyList<Preference>> GetPreferencesByCategoryAsync(string userId, string category, CancellationToken ct = default)
        => _api.GetAsync<IReadOnlyList<Preference>>(string.Format(ApiRoutes.PreferencesByCategory, userId, category), ct);

    public Task<Preference> GetPreferenceAsync(string userId, string category, string name, CancellationToken ct = default)
        => _api.GetAsync<Preference>(string.Format(ApiRoutes.PreferenceByCategoryAndName, userId, category, name), ct);
}
