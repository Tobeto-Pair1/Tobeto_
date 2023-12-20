using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfEmployeeDal : EfRepositoryBase<Employee, Guid, TobetoDbContext>, IEmployeeDal
    {
        public EfEmployeeDal(TobetoDbContext context) : base(context)
        {
        }

    }
}
