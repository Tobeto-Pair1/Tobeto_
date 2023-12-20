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
    public class EfAsyncLessonDal : EfRepositoryBase<AsyncLesson, Guid, TobetoDbContext>, IAsyncLessonDal
    {
        public EfAsyncLessonDal(TobetoDbContext context) : base(context)
        {
        }
    }
}
