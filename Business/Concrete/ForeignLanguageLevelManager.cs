using AutoMapper;
using Business.Abstract;
using Business.DTOs.ForeignLanguageLevels;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using Entities.Concretes;

namespace Business.Concrete;

public class ForeignLanguageLevelManager : IForeignLanguageLevelService
{
    private readonly IForeignLanguageLevelDal _foreignlanguageLevelDal;
    private readonly IMapper _mapper;

    public ForeignLanguageLevelManager(IForeignLanguageLevelDal foreignlanguageLevelDal, IMapper mapper)
    {
        _foreignlanguageLevelDal = foreignlanguageLevelDal;
        _mapper = mapper;
    }

    public async Task<CreatedForeignLanguageLevelResponse> Add(CreateForeignLanguageLevelRequest createLanguageLevelRequest)
    {
        ForeignLanguageLevel foreignLanguageLevel = _mapper.Map<ForeignLanguageLevel>(createLanguageLevelRequest);
        ForeignLanguageLevel createdLanguageLevel = await _foreignlanguageLevelDal.AddAsync(foreignLanguageLevel);
        CreatedForeignLanguageLevelResponse createdLanguageLevelResponse = _mapper.Map<CreatedForeignLanguageLevelResponse>(createdLanguageLevel);
        return createdLanguageLevelResponse;
    }
 
    public async Task<DeletedForeignLanguageLevelResponse> Delete(DeleteForeignLanguageLevelRequest deleteLanguageLevelRequest)
    {
        ForeignLanguageLevel foreignLanguageLevel = await _foreignlanguageLevelDal.GetAsync(u => u.Id == deleteLanguageLevelRequest.Id);
        ForeignLanguageLevel deletedLanguageLevel = await _foreignlanguageLevelDal.DeleteAsync(foreignLanguageLevel);
        DeletedForeignLanguageLevelResponse deletedLanguageLevelResponse = _mapper.Map<DeletedForeignLanguageLevelResponse>(deletedLanguageLevel);
        return deletedLanguageLevelResponse;
    }

    public async Task<IPaginate<GetListForeignLanguageLevelResponse>> GetListAsync(PageRequest pageRequest)
    {
        var data = await _foreignlanguageLevelDal.GetListAsync(index: pageRequest.PageIndex, size: pageRequest.PageSize);

        var result = _mapper.Map<Paginate<GetListForeignLanguageLevelResponse>>(data);
        return result;
    }

    public async Task<UpdatedForeignLanguageLevelResponse> Update(UpdateForeignLanguageLevelRequest updateLanguageLevelRequest)
    {
        ForeignLanguageLevel foreignLanguageLevel = await _foreignlanguageLevelDal.GetAsync(u => u.Id == updateLanguageLevelRequest.Id);
        _mapper.Map(updateLanguageLevelRequest, foreignLanguageLevel);
        ForeignLanguageLevel updatedLanguageLevel = await _foreignlanguageLevelDal.UpdateAsync(foreignLanguageLevel);
        UpdatedForeignLanguageLevelResponse updatedLanguageLevelResponse = _mapper.Map<UpdatedForeignLanguageLevelResponse>(updatedLanguageLevel);
        return updatedLanguageLevelResponse;
    }
}



