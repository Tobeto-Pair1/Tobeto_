using Entities.Concrete;
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
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees").HasKey( b => b.Id);
            builder.Property( b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property( b => b.DepartmentId).HasColumnName("DepartmentId");
       //     builder.Property( b => b.UserId).HasColumnName("UserId");
            //builder.Property( b =b.Name).HasColumnName("Name");


            builder.HasOne(b => b.Department);
          //  builder.HasOne(b => b.User);
            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}
