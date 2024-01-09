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
            builder.ToTable("Towns").HasKey(an => an.Id);
            builder.Property(t => t.CityId).HasColumnName("CityId").IsRequired();
            builder.Property(t => t.Name).HasColumnName("Name").IsRequired();


            builder.HasOne(t => t.City).WithMany(t=>t.Towns).HasForeignKey(t=>t.CityId);
            builder.HasQueryFilter(t => !t.DeletedDate.HasValue);
        }
    }
}
