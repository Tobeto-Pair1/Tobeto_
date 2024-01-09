using Business.DTOs.Grades;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGradeService
    {
        Task<IPaginate<GetListGradeResponse>> GetListAsync(PageRequest pageRequest);

        Task<CreatedGradeResponse> Add(CreateGradeRequest createGradeRequest);

        Task<UpdatedGradeResponse> Update(UpdateGradeRequest updateGradeRequest);

        Task<DeletedGradeResponse> Delete(DeleteGradeRequest deleteGradeRequest);
    }
}
