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
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("Notifications").HasKey(b => b.Id);
            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.NotificationTypeId).HasColumnName("NotificationTypeId").IsRequired();
            builder.Property(b => b.Title).HasColumnName("Title");
            builder.Property(b => b.Label).HasColumnName("Label");


            builder.HasOne(b => b.NotificationType);
            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}


