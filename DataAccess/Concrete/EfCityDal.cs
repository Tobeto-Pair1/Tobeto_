using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfCityDal : EfRepositoryBase<City, Guid, TobetoDbContext>, ICityDal
    {
        public EfCityDal(TobetoDbContext context) : base(context)
        {
        }

    }
}
