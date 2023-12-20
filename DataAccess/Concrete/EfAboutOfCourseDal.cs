using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concretes;

namespace DataAccess.Concrete;

public class EfAboutOfCourseDal : EfRepositoryBase<AboutOfCourse, Guid, TobetoDbContext>, IAboutOfCourseDal
{
    public EfAboutOfCourseDal(TobetoDbContext context) : base(context)
    {
    }
}