using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfiguration;
public class CourseTypeConfiguration : IEntityTypeConfiguration<CourseType>
{
    public void Configure(EntityTypeBuilder<CourseType> builder)
    {


        builder.ToTable("CourseTypes");
        builder.Property(b => b.Name).HasColumnName("Name").IsRequired();

        builder.HasMany(c => c.Courses);
        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);


    }
}
