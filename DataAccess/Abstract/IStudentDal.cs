using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstract;

public interface IStudentDal:IRepository<Student, Guid>, IAsyncRepository<Student, Guid>
{
    
}