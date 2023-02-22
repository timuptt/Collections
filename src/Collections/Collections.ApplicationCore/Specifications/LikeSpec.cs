using Ardalis.Specification;
using Collections.ApplicationCore.Models;

namespace Collections.ApplicationCore.Specifications;

public class LikeSpec : Specification<Like>, ISingleResultSpecification
{
    public LikeSpec(int userProfileId, int itemId)
    {
        Query
            .Where(l => l.ItemId == itemId && l.UserProfileId == userProfileId);
    }
}