using AutoMapper;
using Business.Abstract;
using Business.DTOs.LessonLanguages;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using Entities.Concretes;

namespace Business.Concrete;

public class LessonLanguageManager : ILessonLanguageService
{
    private readonly ILessonLanguageDal _lessonLanguageDal;
    private readonly IMapper _mapper;
    public LessonLanguageManager(ILessonLanguageDal lessonLanguageDal, IMapper mapper)
    {
        _lessonLanguageDal = lessonLanguageDal;
        _mapper = mapper;
    }


    public async Task<CreatedLessonLanguageResponse> Add(CreateLessonLanguageRequest createLessonLanguageRequest)
    {
        LessonLanguage lessonLanguage = _mapper.Map<LessonLanguage>(createLessonLanguageRequest);
        LessonLanguage createdLessonLanguage = await _lessonLanguageDal.AddAsync(lessonLanguage);
        CreatedLessonLanguageResponse createdLessonLanguageResponse = _mapper.Map<CreatedLessonLanguageResponse>(createdLessonLanguage);
        return createdLessonLanguageResponse;

    }

    public async Task<DeletedLessonLanguageResponse> Delete(DeleteLessonLanguageRequest deleteLessonLanguageRequest)
    {
        LessonLanguage lessonLanguage = await _lessonLanguageDal.GetAsync(l => l.Id == deleteLessonLanguageRequest.Id);
        LessonLanguage createdLessonLanguage = await _lessonLanguageDal.DeleteAsync(lessonLanguage);
        DeletedLessonLanguageResponse deletedLessonLanguageResponse = _mapper.Map<DeletedLessonLanguageResponse>(createdLessonLanguage);
        return deletedLessonLanguageResponse;
    }

    public async Task<IPaginate<GetListLessonLanguageResponse>> GetListAsync(PageRequest pageRequest)
    {
        var data = await _lessonLanguageDal.GetListAsync(index: pageRequest.PageIndex, size: pageRequest.PageSize);
        var result = _mapper.Map<Paginate<GetListLessonLanguageResponse>>(data);
        return result;
    }

    public async Task<UpdatedLessonLanguageResponse> Update(UpdateLessonLanguageRequest updateLessonLanguageRequest)
    {
        LessonLanguage lessonLanguage = await _lessonLanguageDal.GetAsync(l => l.Id == updateLessonLanguageRequest.Id);
        _mapper.Map(updateLessonLanguageRequest, lessonLanguage);
        LessonLanguage createdLessonLanguage = await _lessonLanguageDal.UpdateAsync(lessonLanguage);
        UpdatedLessonLanguageResponse updatedLessonLanguageResponse = _mapper.Map<UpdatedLessonLanguageResponse>(createdLessonLanguage);
        return updatedLessonLanguageResponse;
    }
}