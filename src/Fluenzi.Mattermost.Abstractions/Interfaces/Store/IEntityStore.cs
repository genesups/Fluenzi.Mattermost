using Fluenzi.Mattermost.Models.Common;

namespace Fluenzi.Mattermost.Interfaces.Store;

public interface IEntityStore<TKey, TEntity> where TKey : notnull
{
    TEntity? GetById(TKey id);
    IReadOnlyList<TEntity> GetAll();
    IObservable<TEntity> ObserveById(TKey id);
    IObservable<StoreChange<TEntity>> ObserveChanges();
    void Upsert(TKey id, TEntity entity);
    void UpsertMany(IEnumerable<KeyValuePair<TKey, TEntity>> items);
    void Remove(TKey id);
    void Clear();
}
