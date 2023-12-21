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
    public class HomeworkConfiguration : IEntityTypeConfiguration<Homework>
    {
        public void Configure(EntityTypeBuilder<Homework> builder)
        {
            builder.ToTable("Homeworks").HasKey(b => b.Id);
            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.HomeWorkIsSend).HasColumnName("HomeWorkIsSend");
            builder.Property(b => b.InstructorDescription).HasColumnName("InstructorDescription");
            builder.Property(b => b.StudentDescription).HasColumnName("StudentDescription");
            builder.Property(b => b.LastDate).HasColumnName("LastDate");
            builder.Property(b => b.HomeworkTaskFile).HasColumnName("HomeworkTaskFile");
            builder.Property(b => b.HomeworkTaskFile).HasColumnName("HomeworkTaskFile");
            builder.Property(b => b.HomeworkTaskFile).HasColumnName("HomeworkTaskFile");

            builder.HasOne(b => b.Program);
            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);

    }
    }
}
