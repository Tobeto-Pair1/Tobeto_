using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfiguration;
public class UserSkillConfiguration: IEntityTypeConfiguration<UserSkill>
{
    public void Configure(EntityTypeBuilder<UserSkill> builder)
    {
        builder.ToTable("UserSkills").HasKey(b =>new {b.Id, b.UserId, b.SkillId});
        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(b => b.SkillId).HasColumnName("SkillId");

        builder.HasOne(k => k.User);
        builder.HasOne(k => k.Skill);
        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}
