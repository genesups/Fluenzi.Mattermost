using Fluenzi.Mattermost.Interfaces.Store;
using Fluenzi.Mattermost.Store.Stores;

namespace Fluenzi.Mattermost.Store;

public class MattermostStore : IMattermostStore, IDisposable
{
    public IUserStore Users { get; } = new UserStore();
    public ITeamStore Teams { get; } = new TeamStore();
    public IChannelStore Channels { get; } = new ChannelStore();
    public IPostStore Posts { get; } = new PostStore();
    public IThreadStore Threads { get; } = new ThreadStore();
    public IPreferenceStore Preferences { get; } = new PreferenceStore();
    public IEmojiStore Emojis { get; } = new EmojiStore();
    public IReactionStore Reactions { get; } = new ReactionStore();
    public IStatusStore Statuses { get; } = new StatusStore();
    public ITypingStore Typing { get; } = new TypingStore();

    public void ClearAll()
    {
        Users.Clear();
        Teams.Clear();
        Channels.Clear();
        Posts.Clear();
        Threads.Clear();
        Preferences.Clear();
        Emojis.Clear();
        Reactions.Clear();
        Statuses.Clear();
        Typing.Clear();
    }

    public void Dispose()
    {
        (Users as IDisposable)?.Dispose();
        (Teams as IDisposable)?.Dispose();
        (Channels as IDisposable)?.Dispose();
        (Posts as IDisposable)?.Dispose();
        (Threads as IDisposable)?.Dispose();
        (Preferences as IDisposable)?.Dispose();
        (Emojis as IDisposable)?.Dispose();
        (Reactions as IDisposable)?.Dispose();
        (Statuses as IDisposable)?.Dispose();
        (Typing as IDisposable)?.Dispose();
    }
}
