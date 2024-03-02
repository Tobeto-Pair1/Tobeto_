using AutoMapper;
using Business.Abstract;
using Business.DTOs.Employees;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete;

public class EmployeeManager : IEmployeeService
{
    private readonly IEmployeeDal _employeeDal;
    private readonly IMapper _mapper;

    public EmployeeManager(IEmployeeDal employeeDal,  IMapper mapper)
    {
        _employeeDal = employeeDal;
        _mapper = mapper;
    }

    public async Task<CreatedEmployeeResponse> Add(CreateEmployeeRequest createEmployeeRequest)
    {
        Employee employee = _mapper.Map<Employee>(createEmployeeRequest);
        Employee createdEmployee = await _employeeDal.AddAsync(employee);
        CreatedEmployeeResponse createdEmployeeResponse = _mapper.Map<CreatedEmployeeResponse>(createdEmployee);
        return createdEmployeeResponse;
    }
    public async Task<DeletedEmployeeResponse> Delete(DeleteEmployeeRequest deleteEmployeeRequest)
    {
        Employee employee = await _employeeDal.GetAsync(u => u.Id == deleteEmployeeRequest.Id);
        Employee deletedEmployee = await _employeeDal.DeleteAsync(employee);
        DeletedEmployeeResponse deletedEmployeeResponse = _mapper.Map<DeletedEmployeeResponse>(deletedEmployee);
        return deletedEmployeeResponse;
    }

    public async Task<IPaginate<GetListEmployeeResponse>> GetListAsync(PageRequest pageRequest)
    {
        var data = await _employeeDal.GetListAsync(include: e=>e.Include(e=>e.Department),
         index: pageRequest.PageIndex,
         size: pageRequest.PageSize);

        var result = _mapper.Map<Paginate<GetListEmployeeResponse>>(data);
        return result;
    }

    public async Task<UpdatedEmployeeResponse> Update(UpdateEmployeeRequest updateEmployeeRequest)
    {
        Employee employee = await _employeeDal.GetAsync(u => u.Id == updateEmployeeRequest.Id);
        _mapper.Map(updateEmployeeRequest, employee);
        Employee updateEmployee = await _employeeDal.UpdateAsync(employee);
        UpdatedEmployeeResponse updatedEmployeeResponse = _mapper.Map<UpdatedEmployeeResponse>(updateEmployee);
        return updatedEmployeeResponse;
    }
    public async Task<UserAuth> GetByMail(string email)
    {
        var result = await _employeeDal.GetAsync(u => u.Email == email);
        UserAuth userAuth = _mapper.Map<UserAuth>(result);
        return userAuth;
    }
}
