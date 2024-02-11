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
                
            builder.ToTable("CourseStudents").HasKey( b => b.Id);
            builder.Property( b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property( b => b.StudentId).HasColumnName("StudentId").IsRequired();
            builder.Property( b => b.CourseId).HasColumnName("CourseId").IsRequired();


            builder.HasOne(b => b.Course);
            builder.HasOne(b => b.Student);

            builder.HasQueryFilter( b => !b.DeletedDate.HasValue);

        }
    }
}
