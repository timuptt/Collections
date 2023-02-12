using Ardalis.Specification;
using Collections.ApplicationCore.Models;

namespace Collections.ApplicationCore.Specifications;

public class UserCollectionWithItemsByIdSpecification : Specification<UserCollection>,
    ISingleResultSpecification
{
    public UserCollectionWithItemsByIdSpecification(int collectionId)
    {
        Query
            .Where(c => c.Id == collectionId)
            .Include(c => c.Items)
                .ThenInclude(i => i.ExtraFields)
            .Include(c => c.ExtraFieldValueTypes);
    }
}