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
    public class SubTypeConfiguration : IEntityTypeConfiguration<SubType>
    {
        public void Configure(EntityTypeBuilder<SubType> builder)
        {
            builder.ToTable("SubTypes").HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnName("Id").IsRequired();
            builder.HasQueryFilter(t => !t.DeletedDate.HasValue);
        }
    }
}
