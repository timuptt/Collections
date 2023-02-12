using Ardalis.GuardClauses;
using Collections.Shared.Models;

namespace Collections.ApplicationCore.Models;

public class ExtraFieldValueType : EntityBase<int>
{
    public ValueTypes ValueType { get; set; }
    
    public bool IsRequired { get; set; }

    public bool IsVisible { get; set; }

    public IEnumerable<UserCollection> UserCollections { get; set; }
}