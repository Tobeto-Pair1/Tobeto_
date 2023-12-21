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
    public interface IHomeworkService
    {
        Task<IPaginate<GetListHomeworkResponse>> GetListAsync(PageRequest pageRequest);
        Task<CreatedHomeworkResponse> Add(CreateHomeworkRequest createHomeworkRequest);

        Task<DeletedHomeworkResponse> Delete(DeleteHomeworkRequest deleteHomeworkRequest);
        Task<UpdatedHomeworkResponse> Update(UpdateHomeworkRequest updateHomeworkRequest);
    }
}
