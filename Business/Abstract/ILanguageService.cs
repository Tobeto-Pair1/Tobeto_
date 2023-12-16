using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ILanguageService
    {
        Task<IPaginate<GetListLanguageResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedLanguageResponse> Add(CreateLanguageRequest createLanguageRequest);

        Task<UpdatedLanguageResponse> Update(UpdateLanguageRequest updateLanguageRequest);

        Task<DeletedLanguageResponse> Delete(DeleteLanguageRequest deleteLanguageRequest);


    }
}
