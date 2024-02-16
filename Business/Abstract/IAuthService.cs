using Business.DTOs.Employees;
using Business.DTOs.Instructors;
using Business.DTOs.Users;
using Core.Entities.Concrete;
using Core.Utilities.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface IAuthService
{
    Task<AccessToken> Register(UserForRegisterRequest userForRegisterRequest, string password);
    Task<AccessToken> Login(UserForLoginRequest userForLoginRequest);
    Task<AccessToken> AuthCreateAccessToken(UserAuth userAuth);

    //Task<CreatedEmployeeResponse> EmployeeRegister(CreateEmployeeRequest createEmployeeRequest, string password);
    Task<CreatedEmployeeResponse> EmployeeRegister(EmployeeForRegisterRequest employeeForRegisterRequest, string password);
    Task<AccessToken> EmployeeLogin(EmployeeForLoginRequest employeeForLoginRequest);
    Task<AccessToken> EmployeeCreateAccessToken(UserAuth userAuth);

    //  Task<CreatedInstructorResponse> InstructorRegister(CreateInstructorRequest createInstructorRequest, string password);
    Task<CreatedInstructorResponse> InstructorRegister(InstructorForRegisterRequest ınstructorForRegisterRequest, string password);
    Task<AccessToken> InstructorLogin(InstructorForLoginRequest ınstructorForLoginRequest);
    Task<AccessToken> InstructorCreateAccessToken(UserAuth userAuth);

}
