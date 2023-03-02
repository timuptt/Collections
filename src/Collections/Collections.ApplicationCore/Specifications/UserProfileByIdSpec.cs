using Ardalis.Specification;
using Collections.ApplicationCore.Models;

namespace Collections.ApplicationCore.Specifications;

public class UserProfileByIdSpec : Specification<UserProfile>, ISingleResultSpecification
{
    public UserProfileByIdSpec(int id)
    {
        Query
            .Where(p => p.Id == id)
            .EnableCache(nameof(UserProfileByIdSpec), id);
    }
}