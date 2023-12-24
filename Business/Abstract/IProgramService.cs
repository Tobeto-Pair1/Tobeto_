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
    public interface IProgramService
    {
        Task<IPaginate<GetListProgramResponse>> GetListAsync(PageRequest pageRequest);

        Task<CreatedProgramResponse> Add(CreateProgramRequest createProgramRequest);

        Task<UpdatedProgramResponse> Update(UpdateProgramRequest updateProgramRequest);

        Task<DeletedProgramResponse> Delete(DeleteProgramRequest deleteProgramRequest);
    }
}
