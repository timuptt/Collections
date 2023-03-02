using System.Linq.Expressions;
using Collections.ApplicationCore.Models;

namespace Collections.Web.Filters;

public class CollectionFilter : IFilter<UserCollection>
{
    private static readonly Dictionary<string, Expression<Func<UserCollection, object?>>> _orderPredicates =
        new ()
        {
            { nameof(UserCollection.Id), u => u.Id },
            { nameof(UserCollection.Title), u => u.Title },
            { nameof(UserCollection.Description), u => u.Description },
            { nameof(UserCollection.UserCollectionTheme.Theme), u => u.UserCollectionTheme.Theme},
            { "Items count", u => u.Items.Count }
        };

    public Expression<Func<UserCollection, object?>>? GetSortingPredicate(string propertyName) =>
        _orderPredicates.TryGetValue(propertyName, out var value) ? value : null;
}