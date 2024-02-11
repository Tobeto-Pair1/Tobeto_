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
        builder.ToTable("CourseTypes").HasKey(b => b.Id);
        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.Name).HasColumnName("Name").IsRequired();

        builder.HasMany(b => b.Courses);
        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);


    }
}
