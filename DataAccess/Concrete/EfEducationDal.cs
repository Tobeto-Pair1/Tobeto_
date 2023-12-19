using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete;

public class EfEducationDal : EfRepositoryBase<UserEducation, int, TobetoDbContext>, IEducationDal
{
    public EfEducationDal(TobetoDbContext context) : base(context)
    {
    }
}
