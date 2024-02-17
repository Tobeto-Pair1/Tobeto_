using Business.DTOs.Employees;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using Core.Entities.Concrete;
using Core.Utilities.Security.JWT;

namespace Business.Abstract;

public interface IEmployeeService
{

    Task<IPaginate<GetListEmployeeResponse>> GetListAsync(PageRequest pageRequest);

    Task<CreatedEmployeeResponse> Add(CreateEmployeeRequest createEmployeeRequest);

    Task<UpdatedEmployeeResponse> Update(UpdateEmployeeRequest updateEmployeeRequest);

    Task<DeletedEmployeeResponse> Delete(DeleteEmployeeRequest deleteEmployeeRequest);
    Task<UserAuth> GetByMail(string email);
}
