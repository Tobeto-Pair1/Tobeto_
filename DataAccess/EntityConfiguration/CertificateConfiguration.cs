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
    public class CertificateConfiguration: IEntityTypeConfiguration<Certificate>
    {
       
        public void Configure(EntityTypeBuilder<Certificate> builder)
        {
            builder.ToTable("Certificates").HasKey(b => b.Id);
            builder.Property(b => b.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(b => b.FileName).HasColumnName("FileName");
            builder.Property(b => b.FileType).HasColumnName("FileType");
           

     
            builder.HasOne(b => b.User);
            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}
