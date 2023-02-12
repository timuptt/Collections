using Collections.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Collections.Infrastructure.Data.Configuration;

public class UserCollectionThemeEntityConfiguration : IEntityTypeConfiguration<UserCollectionTheme>
{
    public void Configure(EntityTypeBuilder<UserCollectionTheme> builder)
    {
        builder
            .Property(t => t.Theme)
            .HasMaxLength(40)
            .IsRequired();
    }
}