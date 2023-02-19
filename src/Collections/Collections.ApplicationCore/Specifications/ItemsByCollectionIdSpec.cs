using Ardalis.Specification;
using Collections.ApplicationCore.Models;

namespace Collections.ApplicationCore.Specifications;

public class ItemsByCollectionIdSpec : Specification<Item>, ISingleResultSpecification
{
    public ItemsByCollectionIdSpec(int collectionId)
    {
        Query
            .Where(i => i.UserCollectionId == collectionId)
            .Include(i => i.ExtraFields);
    }
}