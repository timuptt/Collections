using System.Linq.Expressions;
using Ardalis.Specification;
using Collections.ApplicationCore.Models;

namespace Collections.ApplicationCore.Specifications;

public class ItemsByTagFilteredPaginatedSpec : Specification<Item>
{
    public ItemsByTagFilteredPaginatedSpec(int tagId, int start, int length, string? searchTerm, Expression<Func<Item, object?>>? sortPredicate, string? order)
    {
        Query
            .AsNoTracking()
            .Where(i => i.Tags.Any(t => t.Id == tagId))
            .Skip(start)
            .Take(length);

        if (!string.IsNullOrEmpty(searchTerm))
        {
            searchTerm = "%" + searchTerm + "%";
            Query
                .Search(i => i.Title, searchTerm)
                .Search(i => i.UserCollection.Title, searchTerm);
        }

        if (sortPredicate == null) return;
        if (order == "asc")
        {
            Query
                .OrderBy(sortPredicate);
            return;
        }
        Query
            .OrderByDescending(sortPredicate);
    }
}