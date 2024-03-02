using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfiguration;

public class ImageConfiguration : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.ToTable("Images").HasKey(b => b.Id);
        builder.Property(b => b.Id).HasColumnName("Id");
        builder.Property(b => b.FileName).HasColumnName("FileName");
        builder.Property(b => b.FileUrl).HasColumnName("FileUrl");

        builder.HasOne(b => b.User);
        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}