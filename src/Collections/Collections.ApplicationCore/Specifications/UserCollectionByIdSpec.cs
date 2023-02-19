using Ardalis.Specification;
using Collections.ApplicationCore.Models;

namespace Collections.ApplicationCore.Specifications;

public class UserCollectionByIdSpec : Specification<UserCollection>, ISingleResultSpecification
{
    public UserCollectionByIdSpec(int id)
    {
        Query
            .Where(c => c.Id == id)
            .Include(c => c.ExtraFieldValueTypes);
    }
}