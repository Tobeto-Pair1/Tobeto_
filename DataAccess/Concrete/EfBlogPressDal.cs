using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concretes;

namespace DataAccess.Concrete;

//BlogPress
public class EfBlogPressDal : EfRepositoryBase<BlogPress, Guid, TobetoDbContext>, IBlogPressDal
{
    public EfBlogPressDal(TobetoDbContext context) : base(context)
    {
    }
}