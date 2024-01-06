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
    public class SocialMediaConfiguration : IEntityTypeConfiguration<SocialMedia>
    {
        public void Configure(EntityTypeBuilder<SocialMedia> builder)
        {
            builder.ToTable("SocialMedias").HasKey(b => new { b.Id});
            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.Name).HasColumnName("Name");
            builder.Property(b => b.Link).HasColumnName("Link");



            builder.HasMany(b => b.UserSocials).WithOne(b => b.SocialMedia);
            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}
