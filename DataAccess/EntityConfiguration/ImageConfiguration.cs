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
            builder.ToTable("Images").HasKey(an => an.Id); 
            builder.Property(an => an.ImageUrl).HasColumnName("ImageUrl");
            builder.Property(an => an.UserId).HasColumnName("UserId");


            builder.HasOne(an => an.User);

            builder.HasQueryFilter(an => !an.DeletedDate.HasValue);
        }
    }
}
