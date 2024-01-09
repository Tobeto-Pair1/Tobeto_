using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concretes;

namespace DataAccess.Concrete;

public class EfForeignLanguageLevelDal : EfRepositoryBase<ForeignLanguageLevel, Guid, TobetoDbContext>, IForeignLanguageLevelDal
{
    public EfForeignLanguageLevelDal(TobetoDbContext context) : base(context)
    {
    }
}