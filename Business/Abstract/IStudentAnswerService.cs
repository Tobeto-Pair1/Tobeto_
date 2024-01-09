using Business.DTOs.StudentAnswers;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IStudentAnswerService
    {

        Task<IPaginate<GetListStudentAnswerResponse>> GetListAsync(PageRequest pageRequest);

        Task<CreatedStudentAnswerResponse> Add(CreateStudentAnswerRequest createStudentAnswerRequest);

        Task<UpdatedStudentAnswerResponse> Update(UpdateStudentAnswerRequest updateStudentAnswerRequest);

        Task<DeletedStudentAnswerResponse> Delete(DeleteStudentAnswerRequest deleteStudentAnswerRequest);
    }
}
