using Ardalis.Specification;
using Collections.ApplicationCore.Models;

namespace Collections.ApplicationCore.Specifications;

public class ExtraFieldValueTypesSpec : Specification<ExtraFieldValueType>, ISingleResultSpecification
{
    public ExtraFieldValueTypesSpec(int collectionId)
    {
        Query
            .Where(f => f.UserCollectionId == collectionId);
    }
}