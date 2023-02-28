using Collections.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Collections.Infrastructure.Data.Configuration;

public class TagEntityConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder
            .HasKey(t => t.Id);
        builder
            .Property(t => t.Id)
            .ValueGeneratedOnAdd();
        builder
            .HasMany(t => t.Items)
            .WithMany(i => i.Tags);
        builder
            .Property(t => t.Title)
            .HasMaxLength(40);
    }
}