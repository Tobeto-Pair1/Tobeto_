using Core.DataAccess.Repositories;
using DataAccess.Context;
using Entities.Concretes;

namespace DataAccess.Abstract;

public class EfSocialMediaDal : EfRepositoryBase<SocialMedia, int, TobetoDbContext>, ISocialMediaDal
{
    public EfSocialMediaDal(TobetoDbContext context) : base(context)
    {
    }
}