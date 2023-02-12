using Collections.ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Collections.Infrastructure.Data.Configuration;

public class CommentEntityConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder
            .Property(c => c.ApplicationUserId)
            .IsRequired();
        builder
            .Property(c => c.Body)
            .HasMaxLength(512)
            .IsRequired();
    }
}