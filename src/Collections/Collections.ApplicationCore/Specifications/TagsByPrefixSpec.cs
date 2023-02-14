using Ardalis.Specification;
using Collections.ApplicationCore.Models;

namespace Collections.ApplicationCore.Specifications;

public class TagsByPrefixSpec : Specification<Tag>, ISingleResultSpecification
{
    public TagsByPrefixSpec(string prefix, int count)
    {
        var searchTerm = prefix + "%";
        Query
            .Search(t => t.Title, searchTerm)
            .OrderBy(t => t.Title)
            .Take(count);
    }
}