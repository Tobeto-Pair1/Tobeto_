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
    public class CourseStudentConfiguration : IEntityTypeConfiguration<CourseStudent>
    {
        public void Configure(EntityTypeBuilder<CourseStudent> builder)
        {

            builder.ToTable("CourseStudents").HasKey(an => an.Id);
            builder.Property(an => an.Id).HasColumnName("Id").IsRequired();
            builder.Property(an => an.StudentId).HasColumnName("StudentId").IsRequired();
            builder.Property(an => an.CourseId).HasColumnName("CourseId").IsRequired();


            builder.HasOne(b => b.Course);
            builder.HasOne(b => b.Student);

            builder.HasQueryFilter(an => !an.DeletedDate.HasValue);

        }
    }
}
