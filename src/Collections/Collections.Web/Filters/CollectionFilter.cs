using System.Linq.Expressions;
using Collections.ApplicationCore.Models;
using Collections.Shared.Constants.Filtering;

namespace Collections.Web.Filters;

public class CollectionFilter : IFilter<UserCollection>
{
    private readonly Dictionary<string, Expression<Func<UserCollection, object?>>> _orderPredicates =
        new Dictionary<string, Expression<Func<UserCollection, object?>>>()
        {
            { nameof(UserCollection.Id), u => u.Id },
            { nameof(UserCollection.Title), u => u.Id },
            { nameof(UserCollection.Description), u => u.Description },
            { "ItemsCount", u => u.Items.Count }
        };

    private readonly Dictionary<string, Expression<Func<UserCollection, string>>> _searchPredicates =
        new Dictionary<string, Expression<Func<UserCollection, string>>>()
        {
            { nameof(UserCollection.Title), u => u.Title },
            { nameof(UserCollection.Description), u => u.Description }
        };

    private static OrderEnum _sortOrder = OrderEnum.Descending;

    public IEnumerable<string> GetOrderProperties() => _orderPredicates.Keys;

    public IEnumerable<string> GetSearchProperties() => _searchPredicates.Keys;

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
    public Expression<Func<UserCollection, string>>? GetSearchPredicate(string propertyName)
    {
        return _searchPredicates.TryGetValue(propertyName, out var value) ? value : null;
    }

    public Expression<Func<UserCollection, object?>>? GetOrderPredicate(string propertyName)
    {
        return _orderPredicates.TryGetValue(propertyName, out var value) ? value : null;
    }
}