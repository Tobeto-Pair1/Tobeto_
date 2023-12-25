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
    public class EfCompanyDal : EfRepositoryBase<Company, Guid, TobetoDbContext>, ICompanyDal
    {
        public EfCompanyDal(TobetoDbContext context) : base(context)
        {
        }
    }
}



