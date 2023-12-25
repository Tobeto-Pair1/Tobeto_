using Business.DTOs.AsyncLessons;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface IAsyncLessonService
{
    Task<IPaginate<GetListAsyncLessonResponse>> GetListAsync(PageRequest pageRequest);

    Task<CreatedAsyncLessonResponse> Add(CreateAsyncLessonRequest createAsyncLessonRequest);

    Task<UpdatedAsyncLessonResponse> Update(UpdateAsyncLessonRequest updateAsyncLessonRequest);

    Task<DeletedAsyncLessonResponse> Delete(DeleteAsyncLessonRequest deleteAsyncLessonRequest);
}
