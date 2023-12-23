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
    public class UserEducationConfiguration : IEntityTypeConfiguration<UserEducation>
    {
        public void Configure(EntityTypeBuilder<UserEducation> builder)
        {
            builder.ToTable("UserEducations").HasKey(b => b.Id);
            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(b => b.University).HasColumnName("University");
            builder.Property(b => b.Department).HasColumnName("Department");
            builder.Property(b => b.EducationType).HasColumnName("EducationType");
            builder.Property(b => b.Department).HasColumnName("Department");
            builder.Property(b => b.GraduationDate).HasColumnName("GraduationDate");


            builder.HasOne(b => b.User);
            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}
