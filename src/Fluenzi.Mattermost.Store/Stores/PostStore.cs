using Fluenzi.Mattermost.Interfaces.Store;
using Fluenzi.Mattermost.Models.Common;
using Fluenzi.Mattermost.Models.Posts;
using R3;

namespace Fluenzi.Mattermost.Store.Stores;

public class PostStore : EntityStore<string, Post>, IPostStore
{
    public IReadOnlyList<Post> GetByChannelId(string channelId, int limit = 60)
        => GetAll()
            .Where(p => p.ChannelId == channelId)
            .OrderByDescending(p => p.CreateAt)
            .Take(limit)
            .ToList();

    public IReadOnlyList<Post> GetThreadPosts(string rootPostId)
        => GetAll()
            .Where(p => p.RootId == rootPostId || p.Id == rootPostId)
            .OrderBy(p => p.CreateAt)
            .ToList();

    public IObservable<IReadOnlyList<Post>> ObserveByChannelId(string channelId)
    {
        return System.Reactive.Linq.Observable.Create<IReadOnlyList<Post>>(observer =>
        {
            observer.OnNext(GetByChannelId(channelId));
            var disposable = ((IObservable<StoreChange<Post>>)ObserveChanges()).Subscribe(change =>
            {
                if (change.Entity.ChannelId == channelId)
                    observer.OnNext(GetByChannelId(channelId));
            });
            return System.Reactive.Disposables.Disposable.Create(() => disposable.Dispose());
        });
    }
}
