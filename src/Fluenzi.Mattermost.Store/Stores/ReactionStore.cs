using System.Collections.Concurrent;
using Fluenzi.Mattermost.Interfaces.Store;
using Fluenzi.Mattermost.Models.Reactions;
using R3;

namespace Fluenzi.Mattermost.Store.Stores;

public class ReactionStore : IReactionStore, IDisposable
{
    private readonly ConcurrentDictionary<string, ConcurrentBag<Reaction>> _byPost = new();
    private readonly Subject<string> _postChanged = new();

    public IReadOnlyList<Reaction> GetByPostId(string postId)
        => _byPost.TryGetValue(postId, out var reactions) ? reactions.ToList() : [];

    public IObservable<IReadOnlyList<Reaction>> ObserveByPostId(string postId)
    {
        return System.Reactive.Linq.Observable.Create<IReadOnlyList<Reaction>>(observer =>
        {
            observer.OnNext(GetByPostId(postId));
            var disposable = _postChanged
                .Where(id => id == postId)
                .Subscribe(_ => observer.OnNext(GetByPostId(postId)));
            return System.Reactive.Disposables.Disposable.Create(() => disposable.Dispose());
        });
    }

    public void AddReaction(Reaction reaction)
    {
        var bag = _byPost.GetOrAdd(reaction.PostId!, _ => new ConcurrentBag<Reaction>());
        if (!bag.Any(r => r.UserId == reaction.UserId && r.EmojiName == reaction.EmojiName))
        {
            bag.Add(reaction);
            _postChanged.OnNext(reaction.PostId!);
        }
    }

    public void RemoveReaction(string userId, string postId, string emojiName)
    {
        if (_byPost.TryGetValue(postId, out var bag))
        {
            var filtered = bag.Where(r => !(r.UserId == userId && r.EmojiName == emojiName)).ToList();
            _byPost[postId] = new ConcurrentBag<Reaction>(filtered);
            _postChanged.OnNext(postId);
        }
    }

    public void Clear()
    {
        _byPost.Clear();
    }

    public void Dispose()
    {
        _postChanged.Dispose();
    }
}
