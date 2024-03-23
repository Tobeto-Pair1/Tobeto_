using Business.DTOs.AboutOfCourses;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;

namespace Business.Abstract;

public interface IAboutOfCourseService
{
    Task<IPaginate<GetListAboutOfCourseResponse>> GetListAsync(PageRequest pageRequest);

    Task<CreatedAboutOfCourseResponse> Add(CreateAboutOfCourseRequest createAboutOfCourseRequest);

    Task<UpdatedAboutOfCourseResponse> Update(UpdateAboutOfCourseRequest updateAboutOfCourseRequest);

    Task<DeletedAboutOfCourseResponse> Delete(DeleteAboutOfCourseRequest deleteAboutOfCourseRequest);
    Task<IPaginate<GetListAboutOfCourseResponse>> GetListByCourse(Guid courseId);
}