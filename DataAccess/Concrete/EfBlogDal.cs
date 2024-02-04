using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concretes;

namespace DataAccess.Concrete;

public class EfBlogDal : EfRepositoryBase<Blog, Guid, TobetoDbContext>, IBlogDal
{
    public EfBlogDal(TobetoDbContext context) : base(context)
    {
    }
}