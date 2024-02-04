using Business.DTOs.CourseProgram;
using Business.DTOs.Requests;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICourseProgramService
    {
        Task<IPaginate<GetListCourseProgramResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedCourseProgramResponse> Add(CreateCourseProgramRequest createCourseProgramRequest);

        Task<DeletedCourseProgramResponse> Delete(DeleteCourseProgramRequest deleteCourseProgramRequest);
        Task<UpdatedCourseProgramResponse> Update(UpdateCourseProgramRequest updateCourseProgramRequest);
    }
}
