using Ardalis.Specification;
using Collections.ApplicationCore.Models;

namespace Collections.ApplicationCore.Specifications;

public class LastItemsSpecification : Specification<Item>, ISingleResultSpecification
{
    public LastItemsSpecification()
    {
        Query
            .OrderByDescending(i => i.AddedOn)
            .Take(5);
    }
}