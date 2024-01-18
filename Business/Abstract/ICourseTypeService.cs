using Business.DTOs.Categories;
using Business.DTOs.CourseType;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;
public interface ICourseTypeService
{
    Task<IPaginate<GetListCourseTypeResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedCourseTypeResponse> Add(CreateCourseTypeRequest createCourseType);

    Task<DeletedCourseTypeResponse> Delete(DeleteCourseTypeRequest deleteCourseTypeRequest);
    Task<UpdatedCourseTypeResponse> Update(UpdateCourseTypeRequest updateCCourseTypeRequest);

}
