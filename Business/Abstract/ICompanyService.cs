using Business.DTOs.Company;
using Business.DTOs.Requests;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICompanyService
    {
        Task<IPaginate<GetListCompanyResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedCompanyResponse> Add(CreateCompanyRequest createCompanyRequest);

        Task<DeletedCompanyResponse> Delete(DeleteCompanyRequest deleteCompanyRequest);
        Task<UpdatedCompanyResponse> Update(UpdateCompanyRequest updateCompanyRequest);

    }
}
