using Business.DTOs.Requests;
using Business.Dtos.Responses;
using Business.DTOs.Responses;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICityService
    {
        Task<IPaginate<GetListCityResponse>> GetListAsync(PageRequest pageRequest);

        Task<CreatedCityResponse> Add(CreateCityRequest createCityRequest);

        Task<UpdatedCityResponse> Update(UpdateCityRequest updateCityRequest);

        Task<DeletedCityResponse> Delete(DeleteCityRequest deleteCityRequest);
    }
}
