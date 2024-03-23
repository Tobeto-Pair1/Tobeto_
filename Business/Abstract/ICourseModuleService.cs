using Business.DTOs.CourseModule;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;

namespace Business.Abstract;

public interface ICourseModuleService
{
    Task<IPaginate<GetListCourseModuleResponse>> GetListAsync(PageRequest pageRequest);

    Task<CreatedCourseModuleResponse> Add(CreateCourseModuleRequest createCourseModuleRequest);

    Task<UpdatedCourseModuleResponse> Update(UpdateCourseModuleRequest updateCourseModuleRequest);

    Task<DeletedCourseModuleResponse> Delete(DeleteCourseModuleRequest deleteCourseModuleRequest);
    Task<IPaginate<GetListCourseModuleResponse>> GetListByCourse(Guid courseId);
}
