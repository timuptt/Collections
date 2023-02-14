using Collections.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Collections.Infrastructure.Data.Configuration;

public class ExtraFieldValueTypeConfiguration : IEntityTypeConfiguration<ExtraFieldValueType>
{
    public void Configure(EntityTypeBuilder<ExtraFieldValueType> builder)
    {
        builder
            .Property(c => c.ValueType)
            .HasConversion(
                v => v.ToString(),
                v => (ValueTypes)Enum.Parse(typeof(ValueTypes), v));
    }
}