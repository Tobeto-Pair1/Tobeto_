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
            builder.ToTable("Employees").HasKey(e => e.Id);
            builder.Property(e => e.DepartmentId).HasColumnName("DepartmentId").IsRequired();
            builder.Property(e => e.Name).HasColumnName("Name");
          

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}
