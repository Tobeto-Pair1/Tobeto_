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
    public class EfProgramDal : EfRepositoryBase<Program, Guid, TobetoDbContext>, IProgramDal
    {
        public EfProgramDal(TobetoDbContext context) : base(context)
        {
        }


    }
}
