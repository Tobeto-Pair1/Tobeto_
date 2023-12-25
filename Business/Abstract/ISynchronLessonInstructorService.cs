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
    public interface ISynchronLessonInstructorService
    {
        Task<IPaginate<GetListSynchronLessonInstructorResponse>> GetListAsync(PageRequest pageRequest);

        Task<CreatedSynchronLessonInstructorResponse> Add(CreateSynchronLessonInstructorRequest createSynchronLessonInstructorRequest);

        Task<UpdatedSynchronLessonInstructorResponse> Update(UpdateSynchronLessonInstructorRequest updateSynchronLessonInstructorRequest);

        Task<DeletedSynchronLessonInstructorResponse> Delete(DeleteSynchronLessonInstructorRequest deleteSynchronLessonInstructorRequest);
    }
}
