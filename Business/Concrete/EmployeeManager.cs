using AutoMapper;
using Business.Abstract;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Core.DataAccess.Dynamic;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        IEmployeeDal _employeeDal;
        IMapper _mapper;
        public EmployeeManager(IEmployeeDal employeeDal,IMapper mapper)
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
            Employee employee = _mapper.Map<Employee>(deleteEmployeeRequest);
            Employee deletedEmployee = await _employeeDal.DeleteAsync(employee);
            DeletedEmployeeResponse deletedEmployeeResponse = _mapper.Map<DeletedEmployeeResponse>(deletedEmployee);
            return deletedEmployeeResponse;
        }

        public async Task<IPaginate<GetListEmployeeResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _employeeDal.GetListAsync(include: e => e.Include(e => e.Department).Include(d=>d.User),
             index: pageRequest.PageIndex,
             size: pageRequest.PageSize);

            var result = _mapper.Map<Paginate<GetListEmployeeResponse>>(data);
            return result;
        }

        public async Task<UpdatedEmployeeResponse> Update(UpdateEmployeeRequest updateEmployeeRequest)
        {
            Employee employee = _mapper.Map<Employee>(updateEmployeeRequest);
            Employee updateEmployee = await _employeeDal.UpdateAsync(employee);
            UpdatedEmployeeResponse updatedEmployeeResponse = _mapper.Map<UpdatedEmployeeResponse>(updateEmployee);
            return updatedEmployeeResponse;
        }
    }
}
