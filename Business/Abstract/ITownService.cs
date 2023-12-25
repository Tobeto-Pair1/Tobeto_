using System;
using Business.DTOs.Towns;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;

namespace Business.Abstract
{
    public interface ITownService
	{
        Task<IPaginate<GetListTownResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedTownResponse> Add(CreateTownRequest createTownRequest);

        Task<UpdatedTownResponse> Update(UpdateTownRequest updateTownRequest);

        Task<DeletedTownResponse> Delete(DeleteTownRequest deleteTownRequest);
    }
}

