using System.Linq.Expressions;
using Collections.ApplicationCore.Models;
using Collections.Shared.Constants.Filtering;

namespace Collections.Web.Filters;

public class CollectionFilter : IFilter<UserCollection>
{
    private readonly Dictionary<string, Expression<Func<UserCollection, object?>>> _orderPredicates =
        new ()
        {
            { nameof(UserCollection.Id), u => u.Id },
            { nameof(UserCollection.Title), u => u.Title },
            { nameof(UserCollection.Description), u => u.Description },
            { nameof(UserCollection.UserCollectionTheme.Theme), u => u.UserCollectionTheme.Theme},
            { "ItemsCount", u => u.Items.Count }
        };

    private static OrderEnum _sortOrder = OrderEnum.Descending;

    public IEnumerable<string> GetOrderProperties() => _orderPredicates.Keys;

    public OrderEnum GetSortOrder(OrderEnum sortOrder)
    {
        if (_sortOrder != sortOrder)
        {
            _sortOrder = OrderEnum.Ascending;
            return _sortOrder;
        }

        _sortOrder = OrderEnum.Descending;
        return _sortOrder;
    }

    public Expression<Func<UserCollection, object?>>? GetOrderPredicate(string propertyName)
    {
        return _orderPredicates.TryGetValue(propertyName, out var value) ? value : null;
    }
}