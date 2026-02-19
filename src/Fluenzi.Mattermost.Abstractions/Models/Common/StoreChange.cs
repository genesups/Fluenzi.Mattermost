namespace Fluenzi.Mattermost.Models.Common;

/// <summary>
/// Represents a change event from the local store.
/// </summary>
/// <typeparam name="T">The type of entity that changed.</typeparam>
/// <param name="Type">The type of change that occurred.</param>
/// <param name="Entity">The entity that was affected.</param>
public record StoreChange<T>(StoreChangeType Type, T Entity);

/// <summary>
/// Describes the kind of change that occurred to a store entity.
/// </summary>
public enum StoreChangeType
{
    /// <summary>A new entity was added.</summary>
    Added,

    /// <summary>An existing entity was updated.</summary>
    Updated,

    /// <summary>An entity was removed.</summary>
    Removed
}
