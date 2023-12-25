using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.DTOs.SynchronLessons;

namespace Business.Abstract
{
    public interface ISynchronLessonService
    {
        Task<IPaginate<GetListSynchronLessonResponse>> GetListAsync(PageRequest pageRequest);

        Task<CreatedSynchronLessonResponse> Add(CreateSynchronLessonRequest createSynchronLessonRequest);

        Task<UpdatedSynchronLessonResponse> Update(UpdateSynchronLessonRequest updateSynchronLessonRequest);

        Task<DeletedSynchronLessonResponse> Delete(DeleteSynchronLessonRequest deleteSynchronLessonRequest);
    }
}
