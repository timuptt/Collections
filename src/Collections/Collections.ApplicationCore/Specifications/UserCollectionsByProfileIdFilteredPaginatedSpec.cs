using System.Linq.Expressions;
using Ardalis.Specification;
using Collections.ApplicationCore.Models;
using Collections.Shared.Constants.Filtering;

namespace Collections.ApplicationCore.Specifications;

public class UserCollectionsByProfileIdFilteredPaginatedSpec : Specification<UserCollection>, ISingleResultSpecification
{
    public UserCollectionsByProfileIdFilteredPaginatedSpec(
        int userProfileId, 
        int take, 
        int skip,
        Expression<Func<UserCollection, object?>>? orderPredicate = null, 
        string searchTerm = "",
        OrderEnum order = OrderEnum.Ascending)
    {
        Query
            .Where(c => c.UserProfileId == userProfileId)
            .Skip(skip)
            .Take(take);
            
        
        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            Query
                .Search(i => i.Title, "%" + searchTerm + "%")
                .Search(i => i.Description, "%" + searchTerm + "%");
        }

        if (orderPredicate != null)
        {
            if (order == OrderEnum.Ascending)
            {
                Query
                    .OrderBy(orderPredicate);
            }
            else
            {
                Query
                    .OrderByDescending(orderPredicate);
            }
            
        }
    }
}