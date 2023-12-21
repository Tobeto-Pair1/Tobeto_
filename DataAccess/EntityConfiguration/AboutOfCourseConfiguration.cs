using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfiguration;

public class AboutOfCourseConfiguration : IEntityTypeConfiguration<AboutOfCourse>
{
    public void Configure(EntityTypeBuilder<AboutOfCourse> builder)
    {
        builder.ToTable("AboutOfCourses").HasKey(b => b.Id);
        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.CourseId).HasColumnName("CourseId");
        builder.Property(b => b.CategoryId).HasColumnName("CategoryId");
        builder.Property(b => b.ManufacturerId).HasColumnName("ManufacturerId");
        builder.Property(b => b.StartTime).HasColumnName("StartTime");
        builder.Property(b => b.EndTime).HasColumnName("EndTime");
        builder.Property(b => b.SpentTime).HasColumnName("SpentTime");



        builder.HasOne(b => b.Category);
        builder.HasOne(b => b.Manufacturer);
        builder.HasOne(b => b.Course);
        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}
