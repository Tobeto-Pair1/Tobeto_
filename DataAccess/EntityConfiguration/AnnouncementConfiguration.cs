using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concretes;

namespace DataAccess.EntityConfiguration
{
    public class AnnouncementConfiguration : IEntityTypeConfiguration<Announcement>
    {
        public void Configure(EntityTypeBuilder<Announcement> builder)
        {
            builder.ToTable("Announcements").HasKey(an => an.Id);
            builder.Property(an => an.Id).HasColumnName("Id").IsRequired();
            builder.Property(an => an.NotificationTypeId).HasColumnName("NotificationTypeId").IsRequired();
            builder.Property(an => an.Title).HasColumnName("Title");
            builder.Property(an => an.Label).HasColumnName("Label");


            builder.HasOne(b => b.NotificationType);
            builder.HasQueryFilter(an => !an.DeletedDate.HasValue);
        }
    }
}


