using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.Cities;

namespace Business.Abstract
{
    public interface ICityService
    {
        Task<IPaginate<GetListCityResponse>> GetListAsync(PageRequest pageRequest);
        Task<IPaginate<GetListCityResponse>> GetListByCountry(Guid countryId);
        Task<CreatedCityResponse> Add(CreateCityRequest createCityRequest);

        Task<UpdatedCityResponse> Update(UpdateCityRequest updateCityRequest);

        Task<DeletedCityResponse> Delete(DeleteCityRequest deleteCityRequest);
    }
}
