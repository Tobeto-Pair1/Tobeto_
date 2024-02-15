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
    public class ContactInformationConfiguration : IEntityTypeConfiguration<ContactInformation>
    {
        public void Configure(EntityTypeBuilder<ContactInformation> builder)
        {
            builder.ToTable("ContactInformations").HasKey(b => b.Id);
            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.CompanyName).HasColumnName("CompanyName").IsRequired();
            builder.Property(b => b.CompanyTitle).HasColumnName("CompanyTitle").IsRequired();
            builder.Property(b => b.TaxDepartment).HasColumnName("TaxDepartment").IsRequired();
            builder.Property(b => b.TaxNumber).HasColumnName("TaxNumber").IsRequired();
            builder.Property(b => b.Phone).HasColumnName("Phone").IsRequired();
            builder.Property(b => b.Email).HasColumnName("Email").IsRequired();
            builder.Property(b => b.Address).HasColumnName("Address").IsRequired();

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }

}
