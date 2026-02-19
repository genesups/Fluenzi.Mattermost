using System.Collections.Concurrent;
using Fluenzi.Mattermost.Interfaces.Store;
using R3;

namespace Fluenzi.Mattermost.Store.Stores;

public class TypingStore : ITypingStore, IDisposable
{
    private readonly ConcurrentDictionary<string, DateTime> _typing = new(); // "userId:channelId" -> expiry
    private readonly Subject<string> _channelChanged = new();
    private static readonly TimeSpan TypingTimeout = TimeSpan.FromSeconds(5);

    public IReadOnlyList<(string UserId, string ChannelId)> GetTypingUsers(string channelId)
    {
        var now = DateTime.UtcNow;
        return _typing
            .Where(kv => kv.Key.EndsWith($":{channelId}") && kv.Value > now)
            .Select(kv =>
            {
                var parts = kv.Key.Split(':', 2);
                return (parts[0], parts[1]);
            })
            .ToList();
    }

    public IObservable<IReadOnlyList<(string UserId, string ChannelId)>> ObserveTypingUsers(string channelId)
    {
        return System.Reactive.Linq.Observable.Create<IReadOnlyList<(string UserId, string ChannelId)>>(observer =>
        {
            observer.OnNext(GetTypingUsers(channelId));
            var disposable = _channelChanged
                .Where(id => id == channelId)
                .Subscribe(_ => observer.OnNext(GetTypingUsers(channelId)));
            return System.Reactive.Disposables.Disposable.Create(() => disposable.Dispose());
        });
    }

    public void AddTyping(string userId, string channelId)
    {
        var key = $"{userId}:{channelId}";
        _typing[key] = DateTime.UtcNow + TypingTimeout;
        _channelChanged.OnNext(channelId);

        // Schedule removal
        _ = Task.Delay(TypingTimeout).ContinueWith(t =>
        {
            if (_typing.TryGetValue(key, out var expiry) && expiry <= DateTime.UtcNow)
            {
                _typing.TryRemove(key, out _);
                _channelChanged.OnNext(channelId);
            }
        });
    }

    public void Clear()
    {
        _typing.Clear();
    }

    public void Dispose()
    {
        _channelChanged.Dispose();
    }
}
