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
    public class EfQuestionDal : EfRepositoryBase<Question, Guid, TobetoDbContext>, IQuestionDal
    {
        public EfQuestionDal(TobetoDbContext context) : base(context)
        {
        }
    }

}
