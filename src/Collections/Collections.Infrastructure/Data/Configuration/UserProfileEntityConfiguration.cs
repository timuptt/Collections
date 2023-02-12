using Collections.ApplicationCore.Models;
using Collections.Infrastructure.Identity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Collections.Infrastructure.Data.Configuration;

public class UserProfileEntityConfiguration : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder
            .Property(p => p.FirstName)
            .HasMaxLength(40)
            .IsRequired();
        builder
            .Property(p => p.LastName)
            .HasMaxLength(40);
    }
}