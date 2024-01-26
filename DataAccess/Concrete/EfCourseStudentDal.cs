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
    public class EfCourseStudentDal : EfRepositoryBase<CourseStudent, Guid, TobetoDbContext>, ICourseStudentDal
    {
        public EfCourseStudentDal(TobetoDbContext context) : base(context)
        {
        }
    }
}
