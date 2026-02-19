using Fluenzi.Mattermost.Models.Users;
using Fluenzi.Mattermost.Models.Teams;
using Fluenzi.Mattermost.Models.Channels;
using Fluenzi.Mattermost.Models.Posts;
using Fluenzi.Mattermost.Models.Threads;
using Fluenzi.Mattermost.Models.Preferences;
using Fluenzi.Mattermost.Models.Emoji;
using Fluenzi.Mattermost.Models.Reactions;

namespace Fluenzi.Mattermost.Interfaces.Store;

public interface IUserStore : IEntityStore<string, User> { }
public interface ITeamStore : IEntityStore<string, Team> { }

public interface IChannelStore : IEntityStore<string, Channel>
{
    IReadOnlyList<Channel> GetByTeamId(string teamId);
    IObservable<IReadOnlyList<Channel>> ObserveByTeamId(string teamId);
}

public interface IPostStore : IEntityStore<string, Post>
{
    IReadOnlyList<Post> GetByChannelId(string channelId, int limit = 60);
    IReadOnlyList<Post> GetThreadPosts(string rootPostId);
    IObservable<IReadOnlyList<Post>> ObserveByChannelId(string channelId);
}

public interface IThreadStore : IEntityStore<string, UserThread> { }

public interface IPreferenceStore : IEntityStore<string, Preference>
{
    IReadOnlyList<Preference> GetByCategory(string userId, string category);
    Preference? Get(string userId, string category, string name);
}

public interface IEmojiStore : IEntityStore<string, CustomEmoji>
{
    CustomEmoji? GetByName(string name);
}

public interface IReactionStore
{
    IReadOnlyList<Reaction> GetByPostId(string postId);
    IObservable<IReadOnlyList<Reaction>> ObserveByPostId(string postId);
    void AddReaction(Reaction reaction);
    void RemoveReaction(string userId, string postId, string emojiName);
    void Clear();
}

public interface IStatusStore : IEntityStore<string, UserStatus> { }

public interface ITypingStore
{
    IReadOnlyList<(string UserId, string ChannelId)> GetTypingUsers(string channelId);
    IObservable<IReadOnlyList<(string UserId, string ChannelId)>> ObserveTypingUsers(string channelId);
    void AddTyping(string userId, string channelId);
    void Clear();
}

public interface IMattermostStore
{
    IUserStore Users { get; }
    ITeamStore Teams { get; }
    IChannelStore Channels { get; }
    IPostStore Posts { get; }
    IThreadStore Threads { get; }
    IPreferenceStore Preferences { get; }
    IEmojiStore Emojis { get; }
    IReactionStore Reactions { get; }
    IStatusStore Statuses { get; }
    ITypingStore Typing { get; }
    void ClearAll();
}
