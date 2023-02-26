using System.Collections;
using Collections.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Collections.Infrastructure.Data.Configuration;

public class ItemEntityConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder
            .Property(i => i.Title)
            .HasMaxLength(100)
            .IsRequired();
        builder
            .HasIndex(
                i => i.Title
            )
            .HasMethod("GIN")
            .IsTsVectorExpressionIndex("english");
    }
}