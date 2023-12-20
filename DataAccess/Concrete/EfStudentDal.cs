using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concretes;

namespace DataAccess.Concrete;

public class EfStudentDal: EfRepositoryBase<Student, int, TobetoDbContext>, IStudentDal
{
    public EfStudentDal(TobetoDbContext context) : base(context)
    {
    }
}