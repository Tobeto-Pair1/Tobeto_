using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfiguration
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.ToTable("Images").HasKey(b => b.Id);
            builder.Property(b => b.Id).HasColumnName("Id");
            builder.Property(b => b.FileName).HasColumnName("FileName");
            builder.Property(b => b.FileUrl).HasColumnName("FileUrl");
            builder.Property(b => b.Description).HasColumnName("Description");


            builder.HasOne(b => b.User);
            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}