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
            builder.ToTable("UserSocials").HasKey(b =>new { b.Id ,b.SocialMediaId});
            builder.Property(b => b.Id).HasColumnName("UserId").IsRequired();
            builder.Property(b => b.SocialMediaId).HasColumnName("SocialMediaId");
         

            builder.HasOne(b => b.User).WithMany(b=>b.UserSocials).HasForeignKey(b=>b.Id);
            builder.HasOne(b => b.SocialMedia).WithMany(b=>b.UserSocials);
            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }


    }
}
