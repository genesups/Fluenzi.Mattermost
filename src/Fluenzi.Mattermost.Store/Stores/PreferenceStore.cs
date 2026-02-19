using Fluenzi.Mattermost.Interfaces.Store;
using Fluenzi.Mattermost.Models.Preferences;

namespace Fluenzi.Mattermost.Store.Stores;

public class PreferenceStore : EntityStore<string, Preference>, IPreferenceStore
{
    private static string MakeKey(Preference p) => $"{p.UserId}:{p.Category}:{p.Name}";

    public void Add(Preference preference) => Upsert(MakeKey(preference), preference);

    public IReadOnlyList<Preference> GetByCategory(string userId, string category)
        => GetAll().Where(p => p.UserId == userId && p.Category == category).ToList();

    public Preference? Get(string userId, string category, string name)
        => GetById($"{userId}:{category}:{name}");
}
