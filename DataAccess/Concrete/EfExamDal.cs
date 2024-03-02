using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concretes;

namespace DataAccess.Concrete;

public class EfExamDal : EfRepositoryBase<Exam, Guid, TobetoDbContext>, IExamDal
{
    public EfExamDal(TobetoDbContext context) : base(context)
    {
    }
}
