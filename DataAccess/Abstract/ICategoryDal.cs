using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstract;

public interface ICategoryDal : IRepository<Category, Guid>, IAsyncRepository<Category, Guid>
{

}