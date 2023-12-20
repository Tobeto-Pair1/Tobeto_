using System;
using Entities.Concrete;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfiguration
{
	public class UserEducationConfiguration
	{


        public void Configure(EntityTypeBuilder<UserEducation>builder)
        {
            builder.ToTable("UserEducation").HasKey(b => b.Id);
            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.UserId).HasColumnName("UserId");
            builder.Property(b => b.EducationType).HasColumnName("EducationType");
            builder.Property(b => b.Department).HasColumnName("Department");
            builder.Property(b => b.StartDate).HasColumnName("StartDate");
            builder.Property(b => b.GraduationDate).HasColumnName("GraduationDate");

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);

        }

    }
}

