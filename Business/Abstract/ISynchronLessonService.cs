using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using Business.DTOs.SynchronLessons;

namespace Business.Abstract;

public interface ISynchronLessonService
{
    Task<IPaginate<GetListSynchronLessonResponse>> GetListAsync(PageRequest pageRequest);

    Task<CreatedSynchronLessonResponse> Add(CreateSynchronLessonRequest createSynchronLessonRequest);

    Task<UpdatedSynchronLessonResponse> Update(UpdateSynchronLessonRequest updateSynchronLessonRequest);

    Task<DeletedSynchronLessonResponse> Delete(DeleteSynchronLessonRequest deleteSynchronLessonRequest);
    Task<IPaginate<GetListSynchronLessonResponse>> GetListByCourseModule(Guid courseModuleId);
}
