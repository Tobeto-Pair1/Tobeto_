
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
    public interface ISynchronLessonDetailService
    {
        Task<IPaginate<GetListSynchronLessonDetailResponse>> GetListAsync(PageRequest pageRequest);

        Task<CreatedSynchronLessonDetailResponse> Add(CreateSynchronLessonDetailRequest createSynchronLessonDetailRequest);

        Task<UpdatedSynchronLessonDetailResponse> Update(UpdateSynchronLessonDetailRequest updateSynchronLessonDetailRequest);

        Task<DeletedSynchronLessonDetailResponse> Delete(DeleteSynchronLessonDetailRequest deleteSynchronLessonDetailRequest);
    }
}
