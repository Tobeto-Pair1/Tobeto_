using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;

namespace Business.Abstract;

public interface IInstructorService
{

    Task<IPaginate<GetListInstructorResponse>> GetListAsync(PageRequest pageRequest);

    Task<CreatedInstructorResponse> Add(CreateInstructorRequest createInstructorRequest);

    Task<UpdatedInstructorResponse> Update(UpdateInstructorRequest updateInstructorRequest);

    Task<DeletedInstructorResponse> Delete(DeleteInstructorRequest deleteInstructorRequest);

}