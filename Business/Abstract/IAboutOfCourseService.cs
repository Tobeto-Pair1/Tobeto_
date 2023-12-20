using Business.Dtos.Responses;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;

namespace Business.Abstract;

public interface IAboutOfCourseService
{
    Task<IPaginate<GetListAboutOfCourseResponse>> GetListAsync(PageRequest pageRequest);

    Task<CreatedAboutOfCourseResponse> Add(CreateAboutOfCourseRequest createAboutOfCourseRequest);

    Task<UpdatedAboutOfCourseResponse> Update(UpdateAboutOfCourseRequest updateAboutOfCourseRequest);

    Task<DeletedAboutOfCourseResponse> Delete(DeleteAboutOfCourseRequest deletAboutOfCourseRequest);

}