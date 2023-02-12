using Collections.Shared.Models;

namespace Collections.ApplicationCore.Models;

public class Like : EntityBase<int>
{
    public string ApplicationUserId { get; set; }

    public int ItemId { get; set; }
    
    public Item Item { get; set; }
}