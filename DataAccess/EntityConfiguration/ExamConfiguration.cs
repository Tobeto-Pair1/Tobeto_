using Entities.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfiguration
{
    public class ExamConfiguration : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.ToTable("Exams").HasKey(b => b.Id);
            builder.Property(b => b.ExamName).HasColumnName("ExamName").IsRequired();
            builder.Property(b => b.ExamDate).HasColumnName("ExamDate").IsRequired();

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }

}
