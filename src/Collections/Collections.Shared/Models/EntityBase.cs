using Collections.Shared.Interfaces;

namespace Collections.Shared.Models;

public class EntityBase<TId> : IAuditableEntity
{
    public TId Id { get; set; }

    public DateTime AddedOn { get; set; }
    
    public DateTime ModifiedOn { get; set; }
}