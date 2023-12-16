using AutoMapper;
using Business.Abstract;
using Business.DTOs.Request;
using Business.DTOs.Response;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class LanguageManager : ILanguageService
    {
        private readonly ILanguageDal _languageDal;
        private readonly IMapper _mapper;
        
        public LanguageManager(ILanguageDal languageDal, IMapper mapper)
        {
            _languageDal = languageDal;
            _mapper = mapper;
        }

        public async Task<CreatedLanguageResponse> Add(CreateLanguageRequest createLanguageRequest)
        {
            ForeignLanguage foreignLanguage = _mapper.Map<ForeignLanguage>(createLanguageRequest);
            ForeignLanguage createdLanguage = await _languageDal.AddAsync(foreignLanguage);
            CreatedLanguageResponse createdLanguageResponse = _mapper.Map<CreatedLanguageResponse>(createdLanguage);
            return createdLanguageResponse;

        }

        public async Task<DeletedLanguageResponse> Delete(DeleteLanguageRequest deleteLanguageRequest)
        {
            ForeignLanguage foreignLanguage = _mapper.Map<ForeignLanguage>(deleteLanguageRequest);
            ForeignLanguage deletedLanguage = await _languageDal.DeleteAsync(foreignLanguage);
            DeletedLanguageResponse deletedLanguageResponse = _mapper.Map<DeletedLanguageResponse>(deletedLanguage);
            return deletedLanguageResponse;
        }

        public async Task<IPaginate<GetListLanguageResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _languageDal.GetListAsync(include: l => (IIncludableQueryable<ForeignLanguage, object>)l.Include(l => l.Id),
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize);

            var result = _mapper.Map<Paginate<GetListLanguageResponse>>(data);
            return result;
        }

        public async Task<UpdatedLanguageResponse> Update(UpdateLanguageRequest updateLanguageRequest)
        {
            ForeignLanguage foreignLanguage = _mapper.Map<ForeignLanguage>(updateLanguageRequest);
            ForeignLanguage updateLanguage = await _languageDal.UpdateAsync(foreignLanguage);
            UpdatedLanguageResponse updateLanguageResponse = _mapper.Map<UpdatedLanguageResponse>(updateLanguage);
            return updateLanguageResponse;
        }
    }
}
