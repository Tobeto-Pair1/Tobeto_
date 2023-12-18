using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfiguration;

public class CatalogConfiguration : IEntityTypeConfiguration<Catalog>
{
    public void Configure(EntityTypeBuilder<Catalog> builder)
    {



        builder.ToTable("Catalogs").HasKey(o => o.Id);
        builder.Property(o => o.Id).HasColumnName("Id").IsRequired();
        builder.Property(o => o.SubjectId).HasColumnName("SubjectId").IsRequired();
        builder.Property(o => o.CategoryId).HasColumnName("CategoryId").IsRequired();
        builder.Property(o => o.LevelId).HasColumnName("LevelId").IsRequired();
        builder.Property(o => o.SituationId).HasColumnName("SituationId").IsRequired();
        builder.Property(o => o.SoftwareLanguageId).HasColumnName("SoftwareLanguageId").IsRequired();
       


        






    }
}
