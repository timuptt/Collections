using Ardalis.Specification;
using Collections.ApplicationCore.Models;

namespace Collections.ApplicationCore.Specifications;

public class UserCollectionWithItemsByIdSpec : Specification<UserCollection>,
    ISingleResultSpecification
{
    public UserCollectionWithItemsByIdSpec(int collectionId)
    {
        Query
            .Where(c => c.Id == collectionId)
            .Include(c => c.Items)
                .ThenInclude(i => i.ExtraFields)
            .Include(c => c.ExtraFieldValueTypes)
            .EnableCache(nameof(UserCollectionWithItemsByIdSpec), collectionId);
    }
}