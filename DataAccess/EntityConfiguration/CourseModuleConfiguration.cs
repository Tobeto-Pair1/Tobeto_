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
    public class CourseModuleConfiguration : IEntityTypeConfiguration<CourseModule>
    {
        public void Configure(EntityTypeBuilder<CourseModule> builder)
        {
            builder.ToTable("CourseModules").HasKey(an => an.Id);
            builder.Property(an => an.Id).HasColumnName("Id").IsRequired();
            builder.Property(an => an.CourseId).HasColumnName("CourseId").IsRequired();


            builder.HasOne(b => b.Course);
            builder.HasMany(b => b.AsyncLessons);

            builder.HasQueryFilter(an => !an.DeletedDate.HasValue);

  
        }
    }
}
