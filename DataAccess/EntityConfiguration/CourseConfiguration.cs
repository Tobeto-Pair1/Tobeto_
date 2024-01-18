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
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {

            builder.ToTable("Courses").HasKey(b => b.Id);
            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.Name).HasColumnName("Name");
            builder.Property(b => b.CourseTypeId).HasColumnName("CourseTypeId");


            builder.HasMany(b => b.CoursePrograms);
            builder.HasOne(b => b.AboutOfCourse);
            builder.HasOne(b => b.CourseType);
            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}
