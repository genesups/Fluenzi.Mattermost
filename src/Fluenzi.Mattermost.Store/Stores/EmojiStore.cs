using Fluenzi.Mattermost.Interfaces.Store;
using Fluenzi.Mattermost.Models.Emoji;

namespace Fluenzi.Mattermost.Store.Stores;

public class EmojiStore : EntityStore<string, CustomEmoji>, IEmojiStore
{
    public CustomEmoji? GetByName(string name)
        => GetAll().FirstOrDefault(e => e.Name == name);
}
