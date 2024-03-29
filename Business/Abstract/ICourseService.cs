using Business.DTOs.Course;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
namespace Business.Abstract;

public interface ICourseService
{
    Task<IPaginate<GetListCourseResponse>> GetListAsync(PageRequest pageRequest);

    Task<CreatedCourseResponse> Add(CreateCourseRequest createCourseRequest);

    Task<UpdatedCourseResponse> Update(UpdateCourseRequest updateCourseRequest);

    Task<DeletedCourseResponse> Delete(DeleteCourseRequest deleteCourseRequest);
    Task<GetListCourseByDynamicResponse> GetListModelByDynamicQuery(PageRequest pageRequest, DynamicQuery dynamic);
}
