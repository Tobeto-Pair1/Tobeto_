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
    public class CourseProgramConfiguration : IEntityTypeConfiguration<CourseProgram>
    {
        public void Configure(EntityTypeBuilder<CourseProgram> builder)
        {
            {
                builder.ToTable("CoursePrograms").HasKey(an => an.Id);
                builder.Property(an => an.Id).HasColumnName("Id").IsRequired();
                builder.Property(an => an.ProgramId).HasColumnName("ProgramId").IsRequired();
                builder.Property(an => an.CourseId).HasColumnName("CourseId").IsRequired();



                builder.HasOne(b => b.Course);
                builder.HasOne(b => b.Program);

                builder.HasQueryFilter(an => !an.DeletedDate.HasValue);
            }
        }
    }
}

