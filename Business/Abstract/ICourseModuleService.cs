using Business.DTOs.CourseModule;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICourseModuleService
    {
        Task<IPaginate<GetListCourseModuleResponse>> GetListAsync(PageRequest pageRequest);

        Task<CreatedCourseModuleResponse> Add(CreateCourseModuleRequest createCourseModuleRequest);

        Task<UpdatedCourseModuleResponse> Update(UpdateCourseModuleRequest updateCourseModuleRequest);

        Task<DeletedCourseModuleResponse> Delete(DeleteCourseModuleRequest deleteCourseModuleRequest);
    }
}
