using Business.DTOs.Employees;
using Business.DTOs.Users;
using Core.Entities.Concrete;
using Core.Utilities.Security.JWT;

namespace Business.Abstract;

public interface IEmployeeAuthService
{
    Task<CreatedEmployeeResponse> Register(EmployeeForRegisterRequest employeeForRegisterRequest, string password);
    Task<AccessToken> Login(EmployeeForLoginRequest employeeForLoginRequest);
    Task<AccessToken> CreateAccessToken(UserAuth userAuth);
}
