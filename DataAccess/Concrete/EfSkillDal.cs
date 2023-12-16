using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concretes;

namespace DataAccess.Concrete;

public class EfSkillDal : EfRepositoryBase<Skill, int, TobetoDbContext> , ISkillDal
{
    public EfSkillDal(TobetoDbContext context) : base(context)
    {
    }
}
