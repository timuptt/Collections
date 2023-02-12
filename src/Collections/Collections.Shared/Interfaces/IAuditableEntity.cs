namespace Collections.Shared.Interfaces;

public interface IAuditableEntity
{
    public DateTime AddedOn { get; set; }
    
    public DateTime ModifiedOn { get; set; }
}