using Business.DTOs.Questions;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IQuestionService
    {
        Task<IPaginate<GetListQuestionResponse>> GetListAsync(PageRequest pageRequest);

        Task<CreatedQuestionResponse> Add(CreateQuestionRequest createQuestionRequest);

        Task<UpdatedQuestionResponse> Update(UpdateQuestionRequest updateQuestionRequest);

        Task<DeletedQuestionResponse> Delete(DeleteQuestionRequest deleteQuestionRequest);
    }
}
