using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfiguration;

public class CourseStudentConfiguration : IEntityTypeConfiguration<CourseStudent>
{
    public void Configure(EntityTypeBuilder<CourseStudent> builder)
    {
            
        builder.ToTable("CourseStudents").HasKey( b => b.Id);
        builder.Property( b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property( b => b.UserId).HasColumnName("UserId").IsRequired();
        builder.Property( b => b.CourseId).HasColumnName("CourseId").IsRequired();


        builder.HasOne(b => b.Course);
        builder.HasOne(b => b.User);

        builder.HasQueryFilter( b => !b.DeletedDate.HasValue);

    }
}
