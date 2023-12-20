using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;

namespace Business.Abstract;

public interface IStudentService
{
    Task<IPaginate<GetListStudentResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedStudentResponse> Add(CreateStudentRequest createStudentRequest);

    Task<UpdatedStudentResponse> Update(UpdateStudentRequest updateStudentRequest);

    Task<DeletedStudentResponse> Delete(DeleteStudentRequest deleteStudentRequest);
}