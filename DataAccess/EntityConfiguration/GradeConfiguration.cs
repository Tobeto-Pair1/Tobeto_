using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entities.Concretes;

namespace DataAccess.EntityConfiguration;

public class GradeConfiguration : IEntityTypeConfiguration<Grade>
{
    public void Configure(EntityTypeBuilder<Grade> builder)
    {
        builder.ToTable("Grades").HasKey(b => b.Id);
        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.Score).HasColumnName("Score").IsRequired();

       
        builder.HasOne(b => b.Exam);
        builder.HasOne(b => b.User);
        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}
