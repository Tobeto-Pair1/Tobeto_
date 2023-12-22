using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Business.DTOs.Requests;
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
    public interface INewService
    {
        Task<IPaginate<GetListNewResponse>> GetListAsync(PageRequest pageRequest);

        Task<CreatedNewResponse> Add(CreateNewRequest createNewRequest);

        Task<UpdatedNewResponse> Update(UpdateNewRequest updateNewRequest);

        Task<DeletedNewResponse> Delete(DeleteNewRequest deleteNewRequest);
    }
}
