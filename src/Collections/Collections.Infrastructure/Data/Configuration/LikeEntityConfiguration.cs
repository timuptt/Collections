using Collections.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Collections.Infrastructure.Data.Configuration;

public class LikeEntityConfiguration : IEntityTypeConfiguration<Like>
{
    public void Configure(EntityTypeBuilder<Like> builder)
    {
        builder
            .HasKey(l => new { l.UserProfileId, l.ItemId });
        builder
            .HasOne(l => l.UserProfile)
            .WithMany(p => p.Likes)
            .HasForeignKey(l => l.UserProfileId);
        builder
            .HasOne(l => l.Item)
            .WithMany(i => i.Likes)
            .HasForeignKey(l => l.ItemId);
    }
}