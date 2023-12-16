using System;
using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concretes;

namespace DataAccess.Concrete
{
    public class EfTownDal : EfRepositoryBase<Town, int, TobetoDbContext>, ITownDal
    {
        public EfTownDal(TobetoDbContext context) : base(context)
        {
        }
    }
}

