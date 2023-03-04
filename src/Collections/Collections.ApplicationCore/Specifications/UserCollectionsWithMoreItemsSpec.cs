using Ardalis.Specification;
using Collections.ApplicationCore.Models;

namespace Collections.ApplicationCore.Specifications;

public class UserCollectionsWithMoreItemsSpec : Specification<UserCollection>, ISingleResultSpecification
{
    public UserCollectionsWithMoreItemsSpec(int take)
    {
        Query
            .OrderByDescending(c => c.Items.Count)
            .Include(c => c.UserProfile)
            .Include(c => c.UserCollectionTheme)
            .Include(c => c.Items)
            .EnableCache(nameof(UserCollectionsWithMoreItemsSpec))
            .Take(take);
    }
}