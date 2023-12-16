using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;

namespace Business.Abstract;

public interface ISkillService
{
    Task<IPaginate<GetListSkillResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedSkillResponse>Add(CreateSkillRequest createdSkillRequest);

    Task<UpdatedSkillResponse>Update(UpdateSkillRequest updatedSkillRequest);

    Task<DeletedSkillResponse>Delete(DeleteSkillRequest deletedSkillRequest);
}