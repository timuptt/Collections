using System.Linq.Expressions;
using Collections.ApplicationCore.Models;
using Collections.Shared.Constants.Filtering;

namespace Collections.Web.Filters;

public interface IFilter<TEntity>
{
    public Expression<Func<TEntity, string>>? GetSearchPredicate(string propertyName);

    public Expression<Func<TEntity, object?>>? GetOrderPredicate(string propertyName);

    public OrderEnum GetSortOrder(OrderEnum sortOrder);

    public IEnumerable<string> GetOrderProperties();

    public IEnumerable<string> GetSearchProperties();
}