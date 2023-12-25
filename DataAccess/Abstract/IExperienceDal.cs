using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstract;

public interface IExperienceDal : IRepository<Experience, Guid>, IAsyncRepository<Experience, Guid>
{

}