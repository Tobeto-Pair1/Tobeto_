using Business.DTOs.LessonLanguages;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;

namespace Business.Abstract;

public interface ILessonLanguageService
{
    Task<IPaginate<GetListLessonLanguageResponse>> GetListAsync(PageRequest pageRequest);

    Task<CreatedLessonLanguageResponse> Add(CreateLessonLanguageRequest createLessonLanguageRequest);

    Task<UpdatedLessonLanguageResponse> Update(UpdateLessonLanguageRequest updateLessonLanguageRequest);

    Task<DeletedLessonLanguageResponse> Delete(DeleteLessonLanguageRequest deleteLessonLanguageRequest);
}
