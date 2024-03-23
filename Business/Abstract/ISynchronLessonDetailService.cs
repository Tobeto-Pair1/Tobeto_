using Business.DTOs.SynchronLessonDetails;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;

namespace Business.Abstract;

public interface ISynchronLessonDetailService
{
    Task<IPaginate<GetListSynchronLessonDetailResponse>> GetListAsync(PageRequest pageRequest);

    Task<CreatedSynchronLessonDetailResponse> Add(CreateSynchronLessonDetailRequest createSynchronLessonDetailRequest);

    Task<UpdatedSynchronLessonDetailResponse> Update(UpdateSynchronLessonDetailRequest updateSynchronLessonDetailRequest);

    Task<DeletedSynchronLessonDetailResponse> Delete(DeleteSynchronLessonDetailRequest deleteSynchronLessonDetailRequest);
    Task<IPaginate<GetListSynchronLessonDetailResponse>> GetListByCourseModule(Guid courseModuleId);
}
