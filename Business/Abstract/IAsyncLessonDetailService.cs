
using Business.DTOs.AsyncLessonDetail;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAsyncLessonDetailService
    {
        Task<IPaginate<GetListAsyncLessonDetailResponse>> GetListAsync(PageRequest pageRequest);

        Task<CreatedAsyncLessonDetailResponse> Add(CreateAsyncLessonDetailRequest createAsyncLessonDetailRequest);

        Task<UpdatedAsyncLessonDetailResponse> Update(UpdateAsyncLessonDetailRequest updateAsyncLessonDetailRequest);

        Task<DeletedAsyncLessonDetailResponse> Delete(DeleteAsyncLessonDetailRequest deleteAsyncLessonDetailRequest);
    }
}
