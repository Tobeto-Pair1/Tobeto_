using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concretes;

namespace DataAccess.Concrete;

public class EfExperienceDal : EfRepositoryBase<Experience, Guid, TobetoDbContext>, IExperienceDal
{
    public EfExperienceDal(TobetoDbContext context) : base(context)
    {
    }
}