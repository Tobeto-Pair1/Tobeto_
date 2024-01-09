using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstract;

public interface IForeignLanguageLevelDal : IRepository<ForeignLanguageLevel, Guid>, IAsyncRepository<ForeignLanguageLevel, Guid>
{
}