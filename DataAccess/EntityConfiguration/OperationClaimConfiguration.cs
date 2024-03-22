using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfiguration;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(b => b.Id);
        builder.Property(ul => ul.Id).HasColumnName("Id").IsRequired();
        builder.Property(ul => ul.Name).HasColumnName("Name").IsRequired();

       builder.HasData(new OperationClaim { Id = Guid.NewGuid(), Name = "admin" });

        builder.HasMany(b => b.UserOperationClaims);
        builder.HasQueryFilter(ul => !ul.DeletedDate.HasValue);
    }
}