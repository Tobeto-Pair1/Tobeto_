using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concretes;

namespace DataAccess.Concrete;

public class EfStudentDal: EfRepositoryBase<Student, Guid, TobetoDbContext>, IStudentDal
{
    public EfStudentDal(TobetoDbContext context) : base(context)
    {
    }
}