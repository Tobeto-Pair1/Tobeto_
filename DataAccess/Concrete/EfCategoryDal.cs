using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concretes;

namespace DataAccess.Concrete;

public class EfCategoryDal : EfRepositoryBase<Category, int, TobetoDbContext>, ICategoryDal
{
    public EfCategoryDal(TobetoDbContext context) : base(context)
    {

    }
}
    
   