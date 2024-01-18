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
            builder.ToTable("Certificates").HasKey(an => an.Id);
            builder.Property(an => an.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(an => an.FileName).HasColumnName("FileName");
            builder.Property(an => an.FileType).HasColumnName("FileType");
           

     
            builder.HasOne(an => an.User);
            builder.HasQueryFilter(an => !an.DeletedDate.HasValue);
        }
    }
}
