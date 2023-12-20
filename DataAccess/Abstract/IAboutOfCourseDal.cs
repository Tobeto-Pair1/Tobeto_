using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstract;

public interface IAboutOfCourseDal : IRepository<AboutOfCourse, Guid>, IAsyncRepository<AboutOfCourse, Guid>
{

}