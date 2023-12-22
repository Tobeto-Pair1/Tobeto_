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
    public class EfSynchronLessonDal : EfRepositoryBase<SynchronLesson, Guid, TobetoDbContext>, ISynchronLessonDal
    {
        public EfSynchronLessonDal(TobetoDbContext context) : base(context)
        {
        }
    }
 }
