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
    public class EfSynchronLessonDetailDal:EfRepositoryBase<SynchronLessonDetail,Guid,TobetoDbContext>, ISynchronLessonDetailDal
    {
        public EfSynchronLessonDetailDal(TobetoDbContext context): base(context)
        {
            
        }
    }
}
