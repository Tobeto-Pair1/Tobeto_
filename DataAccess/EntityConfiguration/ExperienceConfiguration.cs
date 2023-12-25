using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfiguration;

public class ExperienceConfiguration : IEntityTypeConfiguration<Experience>
{
    public void Configure(EntityTypeBuilder<Experience> builder)
    {
        builder.ToTable("Experiences").HasKey(b => new { b.Id });
        builder.Property(ul => ul.Id).HasColumnName("Id").IsRequired();
        //builder.Property(ul => ul.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(ul => ul.PositionId).HasColumnName("PositionId").IsRequired();
        builder.Property(ul => ul.SectorId).HasColumnName("SectorId").IsRequired();
        builder.Property(ul => ul.CompanyId).HasColumnName("CompanyId").IsRequired();
        builder.Property(ul => ul.CityId).HasColumnName("CityId").IsRequired();
        

        //builder.HasOne(b => b.User).WithMany(b => b.Experiences).HasForeignKey(b => b.Id);
        //builder.HasOne(b => b.Position).WithMany(b => b.Experiences).HasForeignKey(b => b.PositionId);
        //builder.HasOne(b => b.Sector).WithMany(b => b.Experiences).HasForeignKey(b => b.SectorId);
        //builder.HasOne(b => b.Company).WithMany(b => b.Experiences).HasForeignKey(b => b.CompanyId);
        //builder.HasOne(b => b.City).WithMany(b => b.Experiences).HasForeignKey(b => b.CityId);
        builder.HasQueryFilter(ul => !ul.DeletedDate.HasValue);
    }
}