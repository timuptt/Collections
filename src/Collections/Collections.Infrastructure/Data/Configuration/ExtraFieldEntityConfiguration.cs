using Collections.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Collections.Infrastructure.Data.Configuration;

public class ExtraFieldEntityConfiguration : IEntityTypeConfiguration<ExtraField>
{
    public void Configure(EntityTypeBuilder<ExtraField> builder)
    {
        builder
            .Property(f => f.Value)
            .IsRequired();
    }
}