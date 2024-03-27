
using Business.DTOs.Course;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface ICourseService
{
    Task<IPaginate<GetListCourseResponse>> GetListAsync(PageRequest pageRequest);

    Task<CreatedCourseResponse> Add(CreateCourseRequest createCourseRequest);

    Task<UpdatedCourseResponse> Update(UpdateCourseRequest updateCourseRequest);

    Task<DeletedCourseResponse> Delete(DeleteCourseRequest deleteCourseRequest);
    Task<GetListCourseByDynamicResponse> GetListModelByDynamicQuery(PageRequest pageRequest, DynamicQuery dynamic);
}
