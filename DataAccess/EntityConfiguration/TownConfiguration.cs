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
    public class TownConfiguration : IEntityTypeConfiguration<Town>
    {
        public void Configure(EntityTypeBuilder<Town> builder)
        {
            builder.ToTable("Towns").HasKey(b => b.Id);
            builder.Property(b => b.CityId).HasColumnName("CityId").IsRequired();
            builder.Property(b => b.Name).HasColumnName("Name").IsRequired();


            builder.HasOne(t => t.City).WithMany(t=>t.Towns).HasForeignKey(b => b.CityId);
            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}
