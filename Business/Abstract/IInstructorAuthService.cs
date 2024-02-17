using Business.DTOs.Instructors;
using Business.DTOs.Users;
using Core.Entities.Concrete;
using Core.Utilities.Security.JWT;

namespace Business.Abstract;

public interface IInstructorAuthService
{
    Task<AccessToken> Login(InstructorForLoginRequest ınstructorForLoginRequest);
    Task<CreatedInstructorResponse> Register(InstructorForRegisterRequest ınstructorForRegisterRequest, string password);
    Task<AccessToken> CreateAccessToken(UserAuth userAuth);
}