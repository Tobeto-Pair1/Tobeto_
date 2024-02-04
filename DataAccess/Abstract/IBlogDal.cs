using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstract;

public interface IBlogDal : IRepository<Blog, Guid>, IAsyncRepository<Blog, Guid>
{

}