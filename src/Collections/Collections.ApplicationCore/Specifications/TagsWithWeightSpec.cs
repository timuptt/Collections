using Ardalis.Specification;
using Collections.ApplicationCore.Models;

namespace Collections.ApplicationCore.Specifications;

public class TagsWithWeightSpec : Specification<Tag>, ISingleResultSpecification
{
    public TagsWithWeightSpec(int take)
    {
        Query
            .OrderByDescending(t => t.Items.Count)
            .Take(take);
    }
}