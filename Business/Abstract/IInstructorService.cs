using Business.DTOs.Instructors;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using Core.Entities.Concrete;
using Core.Utilities.Security.JWT;

namespace Business.Abstract;

public interface IInstructorService
{

    Task<IPaginate<GetListInstructorResponse>> GetListAsync(PageRequest pageRequest);

    Task<CreatedInstructorResponse> Add(CreateInstructorRequest createInstructorRequest);

    Task<UpdatedInstructorResponse> Update(UpdateInstructorRequest updateInstructorRequest);

    Task<DeletedInstructorResponse> Delete(DeleteInstructorRequest deleteInstructorRequest);

    Task<UserAuth> GetByMail(string email);
}