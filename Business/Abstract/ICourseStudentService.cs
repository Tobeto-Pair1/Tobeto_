
using Business.DTOs.CourseStudent;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICourseStudentService
    {
        Task<IPaginate<GetListCourseStudentResponse>> GetListAsync(PageRequest pageRequest);

        Task<CreatedCourseStudentResponse> Add(CreateCourseStudentRequest createCourseStudentRequest);

        Task<UpdatedCourseStudentResponse> Update(UpdateCourseStudentRequest updateCourseStudentRequest);

        Task<DeletedCourseStudentResponse> Delete(DeleteCourseStudentRequest deleteCourseStudentRequest);
    }
}
