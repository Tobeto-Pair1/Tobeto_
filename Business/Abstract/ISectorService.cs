using System;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;

namespace Business.Abstract
{
    public interface ISectorService
	{
        Task<IPaginate<GetListSectorResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedSectorResponse> Add(CreateSectorRequest createSectorRequest);
        Task<UpdatedSectorResponse> Update(UpdateSectorRequest updateSectorRequest);
        Task<DeletedSectorResponse> Delete(DeleteSectorRequest deleteSectorRequest);
    }
}

