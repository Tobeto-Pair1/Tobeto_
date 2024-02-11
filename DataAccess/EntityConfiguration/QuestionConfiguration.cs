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
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("Questions").HasKey(b => b.Id);
            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.QuestionText).HasColumnName("QuestionText").IsRequired();
            builder.Property(b => b.OptionA).HasColumnName("OptionA").IsRequired();
            builder.Property(b => b.OptionB).HasColumnName("OptionB").IsRequired();
            builder.Property(b => b.OptionC).HasColumnName("OptionC").IsRequired();
            builder.Property(b => b.OptionD).HasColumnName("OptionD").IsRequired();
            builder.Property(b => b.CorrectAnswer).HasColumnName("CorrectAnswer").IsRequired();

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }


}
