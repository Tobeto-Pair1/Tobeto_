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
    public class EfUserEducationDal : EfRepositoryBase<UserEducation, Guid, TobetoDbContext>, IUserEducationDal
    {
        public EfUserEducationDal(TobetoDbContext context) : base(context)
        {
        }
    }

}
