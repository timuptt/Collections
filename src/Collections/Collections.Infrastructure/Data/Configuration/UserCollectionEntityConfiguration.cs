using Collections.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Collections.Infrastructure.Data.Configuration;

public class UserCollectionEntityConfiguration : IEntityTypeConfiguration<UserCollection>
{
    public void Configure(EntityTypeBuilder<UserCollection> builder)
    {
        builder
            .Property(c => c.Title)
            .HasMaxLength(100)
            .IsRequired();
        builder
            .Property(c => c.Description)
            .HasMaxLength(1000)
            .IsRequired();
    }
}