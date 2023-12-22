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
    public class NewConfiguration : IEntityTypeConfiguration<New>
    {

      
        public void Configure(EntityTypeBuilder<New> builder)
        {
            builder.ToTable("News").HasKey(b => b.Id);
            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.Title).HasColumnName("Title");
            builder.Property(b => b.Label).HasColumnName("Label");

            builder.Property(b => b.NotificationId).HasColumnName("NotificationId").IsRequired();


            builder.HasOne(b => b.NotificationType);

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }

}
