using Entities.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfiguration
{
    public class UserSocialConfiguration : IEntityTypeConfiguration<UserSocial>
    {
        public void Configure(EntityTypeBuilder<UserSocial> builder)
        {
            builder.ToTable("UserSocials").HasKey(b => b.Id);
            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.Link).HasColumnName("Link");
            builder.Property(b => b.UserId).HasColumnName("UserId");
            builder.Property(b => b.SocialMediaId).HasColumnName("SocialMediaId");
         

            builder.HasOne(b => b.User).WithMany(b=>b.UserSocials);
            builder.HasOne(b => b.SocialMedia);
            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }


    }
}
