using System.Linq.Expressions;
using Ardalis.Specification;
using Collections.ApplicationCore.Models;

namespace Collections.ApplicationCore.Specifications;

public class UserCollectionFilteredPagedSpec : Specification<UserCollection>
{
    public UserCollectionFilteredPagedSpec(int start, int length, string? searchTerm, Expression<Func<UserCollection, object?>>? sortPredicate, string? order, int userId = 0)
    {
        Query.AsNoTracking();
        
        if (userId > 0)
        {
            Query
                .Where(c => c.UserProfileId == userId);
        }
        
        Query
            .Skip(start)
            .Take(length);

        if (!string.IsNullOrEmpty(searchTerm))
        {
            searchTerm = "%" + searchTerm + "%";
            Query
                .Search(c => c.Title, searchTerm)
                .Search(c => c.Description, searchTerm)
                .Search(c => c.UserCollectionTheme.Theme, searchTerm)
                .Search(c => c.UserProfile.FirstName, searchTerm)
                .Search(c => c.UserProfile.LastName ?? string.Empty, searchTerm);
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