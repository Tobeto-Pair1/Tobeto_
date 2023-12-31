using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstract;

public interface ISkillDal: IRepository<Skill, Guid>, IAsyncRepository<Skill, Guid>
{
    
}