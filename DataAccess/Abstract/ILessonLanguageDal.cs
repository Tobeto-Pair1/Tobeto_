using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstract;

public interface ILessonLanguageDal :  IRepository<LessonLanguage, Guid>, IAsyncRepository<LessonLanguage, Guid>
{
}
