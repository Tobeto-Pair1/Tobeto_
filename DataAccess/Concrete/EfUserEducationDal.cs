using System;
using Core.DataAccess.Repositories;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concretes;

namespace DataAccess.Concrete
{
    public class EfUserEducationDal : EfRepositoryBase<UserEducation, Guid, TobetoDbContext>, IUserEducationDal
    {
        public EfUserEducationDal(TobetoDbContext context) : base(context)
        {
        }
    }
}

