using Business.DTOs.ForeignLanguages;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface IForeignLanguageService
{
    Task<IPaginate<GetListForeignLanguageResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedForeignLanguageResponse> Add(CreateForeignLanguageRequest createLanguageRequest);

    Task<UpdatedForeignLanguageResponse> Update(UpdateForeignLanguageRequest updateLanguageRequest);

    Task<DeletedForeignLanguageResponse> Delete(DeleteForeignLanguageRequest deleteLanguageRequest);


}