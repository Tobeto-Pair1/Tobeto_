using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstract;

public interface IBlogPressDal : IRepository<BlogPress, Guid>, IAsyncRepository<BlogPress, Guid>
{

}