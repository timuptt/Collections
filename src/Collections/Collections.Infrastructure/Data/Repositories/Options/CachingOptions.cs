namespace Collections.Infrastructure.Data.Repositories.Options;

public class CachingOptions
{
    public int LongCachingInterval { get; set; }
    
    public int MediumCachingInterval { get; set; }
    
    public int HotCachingInterval { get; set; }
}