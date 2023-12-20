using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstract;

public interface IInstructorDal : IRepository<Instructor, Guid>, IAsyncRepository<Instructor, Guid>
{

}
