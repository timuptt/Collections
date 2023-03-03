using System.Linq.Expressions;
using Collections.ApplicationCore.Models;

namespace Collections.Web.Filters;

public class ItemFilter : IFilter<Item>
{
    private static readonly Dictionary<string, Expression<Func<Item, object?>>> _sortingPredicates = new()
    {
        { nameof(Item.Id), i => i.Id },
        { nameof(Item.Title), i => i.Title },
        { "Collection", i => i.UserCollection.Title },
        { "Comments", i => i.Comments.Count },
        { "Likes", i => i.Likes.Count }
    };
    public Expression<Func<Item, object?>>? GetSortingPredicate(string propertyName) =>
        _sortingPredicates.TryGetValue(propertyName, out var value) ? value : null;
}