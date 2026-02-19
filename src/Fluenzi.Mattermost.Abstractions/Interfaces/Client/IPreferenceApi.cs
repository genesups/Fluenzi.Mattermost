using Fluenzi.Mattermost.Models.Preferences;

namespace Fluenzi.Mattermost.Interfaces.Client;

public interface IPreferenceApi
{
    Task<IReadOnlyList<Preference>> GetPreferencesAsync(string userId, CancellationToken ct = default);
    Task SavePreferencesAsync(string userId, IEnumerable<Preference> preferences, CancellationToken ct = default);
    Task DeletePreferencesAsync(string userId, IEnumerable<Preference> preferences, CancellationToken ct = default);
    Task<IReadOnlyList<Preference>> GetPreferencesByCategoryAsync(string userId, string category, CancellationToken ct = default);
    Task<Preference> GetPreferenceAsync(string userId, string category, string name, CancellationToken ct = default);
}
