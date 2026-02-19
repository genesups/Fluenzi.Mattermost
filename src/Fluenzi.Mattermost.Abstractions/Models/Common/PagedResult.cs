namespace Fluenzi.Mattermost.Models.Common;

/// <summary>
/// Represents a paginated result set.
/// </summary>
/// <typeparam name="T">The type of items in the result.</typeparam>
/// <param name="Items">The items in this page.</param>
/// <param name="HasMore">Whether there are more items available.</param>
public record PagedResult<T>(IReadOnlyList<T> Items, bool HasMore);
