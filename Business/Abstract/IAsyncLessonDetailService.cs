using Business.DTOs.AsyncLessonDetail;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;

namespace Business.Abstract;

public interface IAsyncLessonDetailService
{
    Task<IPaginate<GetListAsyncLessonDetailResponse>> GetListAsync(PageRequest pageRequest);

    Task<CreatedAsyncLessonDetailResponse> Add(CreateAsyncLessonDetailRequest createAsyncLessonDetailRequest);

    Task<UpdatedAsyncLessonDetailResponse> Update(UpdateAsyncLessonDetailRequest updateAsyncLessonDetailRequest);

    Task<DeletedAsyncLessonDetailResponse> Delete(DeleteAsyncLessonDetailRequest deleteAsyncLessonDetailRequest);
    Task<IPaginate<GetListAsyncLessonDetailResponse>> GetListByLesson(Guid lessonId);
}
