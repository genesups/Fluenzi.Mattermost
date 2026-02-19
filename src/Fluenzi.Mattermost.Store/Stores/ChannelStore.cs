using Fluenzi.Mattermost.Interfaces.Store;
using Fluenzi.Mattermost.Models.Channels;
using Fluenzi.Mattermost.Models.Common;
using R3;

namespace Fluenzi.Mattermost.Store.Stores;

public class ChannelStore : EntityStore<string, Channel>, IChannelStore
{
    public IReadOnlyList<Channel> GetByTeamId(string teamId)
        => GetAll().Where(c => c.TeamId == teamId).ToList();

    public IObservable<IReadOnlyList<Channel>> ObserveByTeamId(string teamId)
    {
        return System.Reactive.Linq.Observable.Create<IReadOnlyList<Channel>>(observer =>
        {
            observer.OnNext(GetByTeamId(teamId));
            var disposable = ((IObservable<StoreChange<Channel>>)ObserveChanges()).Subscribe(_ =>
            {
                observer.OnNext(GetByTeamId(teamId));
            });
            return System.Reactive.Disposables.Disposable.Create(() => disposable.Dispose());
        });
    }
}
