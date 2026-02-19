using System.Collections.Concurrent;
using Fluenzi.Mattermost.Interfaces.Store;
using Fluenzi.Mattermost.Models.Common;
using R3;

namespace Fluenzi.Mattermost.Store.Stores;

public class EntityStore<TKey, TEntity> : IEntityStore<TKey, TEntity>, IDisposable where TKey : notnull
{
    private readonly ConcurrentDictionary<TKey, TEntity> _entities = new();
    private readonly Subject<StoreChange<TEntity>> _changes = new();

    public TEntity? GetById(TKey id) => _entities.TryGetValue(id, out var entity) ? entity : default;

    public IReadOnlyList<TEntity> GetAll() => _entities.Values.ToList();

    public IObservable<TEntity> ObserveById(TKey id)
    {
        return System.Reactive.Linq.Observable.Create<TEntity>(observer =>
        {
            // Emit current value if exists
            if (_entities.TryGetValue(id, out var current))
                observer.OnNext(current);

            // Subscribe to future changes
            var disposable = _changes.Subscribe(change =>
            {
                if (change.Type != StoreChangeType.Removed && _entities.TryGetValue(id, out var entity))
                    observer.OnNext(entity);
            });
            return System.Reactive.Disposables.Disposable.Create(() => disposable.Dispose());
        });
    }

    public IObservable<StoreChange<TEntity>> ObserveChanges()
    {
        return _changes.AsSystemObservable();
    }

    public void Upsert(TKey id, TEntity entity)
    {
        var isNew = !_entities.ContainsKey(id);
        _entities[id] = entity;
        _changes.OnNext(new StoreChange<TEntity>(isNew ? StoreChangeType.Added : StoreChangeType.Updated, entity));
    }

    public void UpsertMany(IEnumerable<KeyValuePair<TKey, TEntity>> items)
    {
        foreach (var (key, value) in items)
            Upsert(key, value);
    }

    public void Remove(TKey id)
    {
        if (_entities.TryRemove(id, out var entity))
            _changes.OnNext(new StoreChange<TEntity>(StoreChangeType.Removed, entity));
    }

    public void Clear()
    {
        var items = _entities.Values.ToList();
        _entities.Clear();
        foreach (var item in items)
            _changes.OnNext(new StoreChange<TEntity>(StoreChangeType.Removed, item));
    }

    public void Dispose()
    {
        _changes.Dispose();
    }
}
