using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfiguration;

public class BlogPressConfiguration : IEntityTypeConfiguration<BlogPress>
{
    public void Configure(EntityTypeBuilder<BlogPress> builder)
    {
        builder.ToTable("BlogsPress").HasKey(b => b.Id);
        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.Title).HasColumnName("Title").IsRequired();
        builder.Property(b => b.Text).HasColumnName("Text").IsRequired();


        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}