using Ardalis.Specification;
using Collections.ApplicationCore.Models;

namespace Collections.ApplicationCore.Specifications;

public class UserCollectionCountSpec : Specification<UserCollection>
{
    public UserCollectionCountSpec(int userId)
    {
        Query
            .AsNoTracking()
            .EnableCache(nameof(UserCollectionCountSpec), userId);
        if (userId > 0)
        {
            Query
                .Where(c => c.UserProfileId == userId);
        }
    }
}