using Collections.ApplicationCore.Models;
using Collections.Infrastructure.Identity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Collections.Infrastructure.Data.Configuration;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder
            .HasOne<UserProfile>(u => u.UserProfile)
            .WithOne()
            .HasForeignKey<ApplicationUser>(u => u.UserProfileId);
    }
}