using Ardalis.Specification;
using Collections.ApplicationCore.Models;

namespace Collections.ApplicationCore.Specifications;

public class UserCollectionsWithMoreItemsSpecification : Specification<UserCollection>, ISingleResultSpecification
{
    public UserCollectionsWithMoreItemsSpecification()
    {
        Query
            .OrderByDescending(c => c.Items.Count)
            .Include(c => c.UserProfile)
            .Include(c => c.UserCollectionTheme)
            .Include(c => c.Items)
            .EnableCache(nameof(UserCollectionsWithMoreItemsSpecification))
            .Take(6);
    }
}