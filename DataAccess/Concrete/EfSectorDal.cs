using System;
using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concretes;

namespace DataAccess.Concrete
{
    public class EfSectorDal : EfRepositoryBase<Sector, int, TobetoDbContext>, ISectorDal
    {
        public EfSectorDal(TobetoDbContext context) : base(context)
        {
        }
    }
}

