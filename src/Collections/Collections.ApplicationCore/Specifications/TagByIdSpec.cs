using Ardalis.Specification;
using Collections.ApplicationCore.Models;

namespace Collections.ApplicationCore.Specifications;

public class TagByIdSpec : Specification<Tag>, ISingleResultSpecification
{
    public TagByIdSpec(int id)
    {
        Query
            .Where(t => t.Id == id);
    }
}