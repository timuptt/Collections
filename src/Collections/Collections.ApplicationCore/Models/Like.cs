using AutoMapper;
using Collections.Shared.Interfaces;

namespace Collections.ApplicationCore.Models;

public class Like : IAggregateRoot
{
    public int UserProfileId { get; set; }
    
    public UserProfile UserProfile { get; set; }
    
    public int ItemId { get; set; }
    
    public Item Item { get; set; }
}