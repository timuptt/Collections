using Collections.Shared.Interfaces;
using Collections.Shared.Models;

namespace Collections.ApplicationCore.Models;

public class ExtraField : EntityBase<int>, IAggregateRoot
{
    public int ExtraFieldValueTypeId { get; set; }
    
    public ExtraFieldValueType ExtraFieldValueType { get; set; }

    public string Value { get; set; }

    public int ItemId { get; set; }
    
    public Item Item { get; set; }
}