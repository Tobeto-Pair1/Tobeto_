using Core.DataAccess.Repositories;
using DataAccess.Context;
using Entities.Concretes;

using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfNewDal : EfRepositoryBase<New, Guid, TobetoDbContext> , INewDal
    {
        public EfNewDal(TobetoDbContext context) : base(context)
        {
        }
    }
}
