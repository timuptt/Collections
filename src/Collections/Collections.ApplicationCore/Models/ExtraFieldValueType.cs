using Ardalis.GuardClauses;
using Collections.Shared.Interfaces;
using Collections.Shared.Models;

namespace Collections.ApplicationCore.Models;

public class ExtraFieldValueType : EntityBase<int>, IAggregateRoot
{
    public ValueTypes ValueType { get; set; }
    
    public bool IsRequired { get; set; }

    public bool IsVisible { get; set; }
    
    public string Name { get; set; }

    public int UserCollectionId { get; set; }
    
    public UserCollection UserCollection { get; set; }
}