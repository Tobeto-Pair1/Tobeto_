using AutoMapper;
using Business.Abstract;
using Business.DTOs.ForeignLanguages;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class ForeignLanguageManager : IForeignLanguageService
{
    IForeignLanguageDal _foreignlanguageDal;
    IMapper _mapper;
    
    public ForeignLanguageManager(IForeignLanguageDal foreignlanguageDal, IMapper mapper)
    {
        _foreignlanguageDal = foreignlanguageDal;
        _mapper = mapper;
    }

    public async Task<CreatedForeignLanguageResponse> Add(CreateForeignLanguageRequest createLanguageRequest)
    {
        ForeignLanguage foreignLanguage = _mapper.Map<ForeignLanguage>(createLanguageRequest);
        ForeignLanguage createdLanguage = await _foreignlanguageDal.AddAsync(foreignLanguage);
        CreatedForeignLanguageResponse createdLanguageResponse = _mapper.Map<CreatedForeignLanguageResponse>(createdLanguage);
        return createdLanguageResponse;

    }

    public async Task<DeletedForeignLanguageResponse> Delete(DeleteForeignLanguageRequest deleteLanguageRequest)
    {
        ForeignLanguage foreignLanguage = await _foreignlanguageDal.GetAsync(u => u.Id == deleteLanguageRequest.Id);
        ForeignLanguage deletedLanguage = await _foreignlanguageDal.DeleteAsync(foreignLanguage);
        DeletedForeignLanguageResponse deletedLanguageResponse = _mapper.Map<DeletedForeignLanguageResponse>(deletedLanguage);
        return deletedLanguageResponse;
    }

    public async Task<IPaginate<GetListForeignLanguageResponse>> GetListAsync(PageRequest pageRequest)
    {
        var data = await _foreignlanguageDal.GetListAsync(index: pageRequest.PageIndex,size: pageRequest.PageSize);

        var result = _mapper.Map<Paginate<GetListForeignLanguageResponse>>(data);
        return result;
    }

    public async Task<UpdatedForeignLanguageResponse> Update(UpdateForeignLanguageRequest updateLanguageRequest)
    {
        ForeignLanguage foreignLanguage = await _foreignlanguageDal.GetAsync(u => u.Id == updateLanguageRequest.Id);
        _mapper.Map(updateLanguageRequest, foreignLanguage);
        ForeignLanguage updateLanguage = await _foreignlanguageDal.UpdateAsync(foreignLanguage);
        UpdatedForeignLanguageResponse updateLanguageResponse = _mapper.Map<UpdatedForeignLanguageResponse>(updateLanguage);
        return updateLanguageResponse;
    }
}



