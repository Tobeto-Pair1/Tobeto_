using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concretes;

namespace DataAccess.Concrete;

public class EfInstructorDal : EfRepositoryBase<Instructor, Guid, TobetoDbContext>, IInstructorDal
{
    public EfInstructorDal(TobetoDbContext context) : base(context)
    {
    }
}