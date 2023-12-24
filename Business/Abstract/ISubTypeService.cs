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
    public interface ISubTypeService
    {

        Task<IPaginate<GetListSubTypeResponse>> GetListAsync(PageRequest pageRequest);

        Task<CreatedSubTypeResponse> Add(CreateSubTypeRequest createSubTypeRequest);

        Task<UpdatedSubTypeResponse> Update(UpdateSubTypeRequest updateSubTypeRequest);

        Task<DeletedSubTypeResponse> Delete(DeleteSubTypeRequest deleteSubTypeRequest);
    }
}
