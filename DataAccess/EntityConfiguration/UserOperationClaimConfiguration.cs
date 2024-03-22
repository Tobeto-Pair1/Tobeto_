using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfiguration;

public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
{
    public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
    {
        builder.ToTable("UserOperationClaims").HasKey(b => b.Id);
        builder.Property(ul => ul.Id).HasColumnName("Id").IsRequired();
        builder.Property(ul => ul.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(ul => ul.OperationClaimId).HasColumnName("OperationClaimId").IsRequired();

        builder.HasOne(b => b.OperationClaim);
        builder.HasQueryFilter(ul => !ul.DeletedDate.HasValue);
    }
}
