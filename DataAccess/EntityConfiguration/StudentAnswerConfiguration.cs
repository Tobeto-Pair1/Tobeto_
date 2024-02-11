using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concretes;

namespace DataAccess.EntityConfiguration
{
    public class StudentAnswerConfiguration : IEntityTypeConfiguration<StudentAnswer>
    {
        public void Configure(EntityTypeBuilder<StudentAnswer> builder)
        {
            builder.ToTable("StudentAnswers").HasKey(b => b.Id);
            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.StudentId).HasColumnName("StudentId").IsRequired();
            builder.Property(b => b.QuestionId).HasColumnName("QuestionId").IsRequired();
            builder.Property(b => b.SelectedOption).HasColumnName("SelectedOption").IsRequired();
            builder.Property(b => b.IsCorrect).HasColumnName("IsCorrect").IsRequired();



            builder.HasOne(b => b.Student);
            builder.HasOne(b => b.Question);
            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }

    }
}
