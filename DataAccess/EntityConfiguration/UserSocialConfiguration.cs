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
            builder.Property(b => b.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(b => b.SocialMediaId).HasColumnName("SocialMediaId");
            builder.Property(b => b.Link).HasColumnName("Link").IsRequired();      

            builder.HasOne(b => b.User);
            builder.HasOne(b => b.SocialMedia);
            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }


    }
}
