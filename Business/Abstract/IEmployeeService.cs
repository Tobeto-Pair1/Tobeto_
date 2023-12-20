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
    public interface IEmployeeService
    {

        Task<IPaginate<GetListEmployeeResponse>> GetListAsync(PageRequest pageRequest);

        Task<CreatedEmployeeResponse> Add(CreateEmployeeRequest createEmployeeRequest);

        Task<UpdatedEmployeeResponse> Update(UpdateEmployeeRequest updateEmployeeRequest);

        Task<DeletedEmployeeResponse> Delete(DeleteEmployeeRequest deleteEmployeeRequest);
    }
}
