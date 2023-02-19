using Ardalis.Specification;
using Collections.ApplicationCore.Models;

namespace Collections.ApplicationCore.Specifications;

public class UserCollectionsCountByProfileIdSpec : Specification<UserCollection>, ISingleResultSpecification
{
    public UserCollectionsCountByProfileIdSpec(int profileId)
    {
        Query
            .Where(c => c.UserProfileId == profileId);
    }
}