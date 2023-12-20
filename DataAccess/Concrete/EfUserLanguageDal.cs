﻿using Core.DataAccess.Repositories;
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
    public class EfUserLanguageDal: EfRepositoryBase<UserLanguage, Guid, TobetoDbContext>, IUserLanguageDal
    {
        public EfUserLanguageDal(TobetoDbContext context) : base(context)
        {
        }
    }

}
