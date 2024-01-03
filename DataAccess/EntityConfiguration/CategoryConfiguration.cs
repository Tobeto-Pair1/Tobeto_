using Entities.Concrete;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories").HasKey(b => b.Id);
            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.Name).HasColumnName("Name").IsRequired();

            builder.HasData(
     new Category { Id = Guid.NewGuid(), Name = "Web Yazılım" },
     new Category { Id = Guid.NewGuid(), Name = "Siber Güvenlik" },
     new Category { Id = Guid.NewGuid(), Name = "Mobil Geliştirme" },
     new Category { Id = Guid.NewGuid(), Name = "Gömülü Yazılım" },
     new Category { Id = Guid.NewGuid(), Name = "Soft Skill Eğitim" }
 );

            builder.HasIndex(indexExpression: b => b.Name, name: "UK_Categories_Name").IsUnique();

            builder.HasOne(b => b.ParentCategory).WithMany(b => b.SubCategory).HasForeignKey("ParentId");
            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }

    }
}


