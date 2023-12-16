using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface IEducationService
{
    Task<IPaginate<GetListEducationResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedEducationResponse> Add(CreateEducationRequest createEducationRequest);
    Task<DeletedEducationResponse> Delete(DeleteEducationRequest deleteEducationRequest);
}
