using Business.DTOs.Experiences;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;

namespace Business.Abstract;

public interface IExperienceService
{

    Task<IPaginate<GetListExperienceResponse>> GetListAsync(PageRequest pageRequest);
    Task<IPaginate<GetListExperienceResponse>> GetListByUser(Guid userId);
    Task<CreatedExperienceResponse> Add(CreateExperienceRequest createExperienceRequest);

    Task<UpdatedExperienceResponse> Update(UpdateExperienceRequest updateExperienceRequest);

    Task<DeletedExperienceResponse> Delete(DeleteExperienceRequest deleteExperienceRequest);

}