using AutoMapper;
using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Business.DTOs.Users;
using Business.Rules;
using Core.Aspects.Autofac.Validation;
using Business.Validations;
using Business.DTOs.Employees;
using Business.DTOs.Instructors;
using Entities.Concretes;

namespace Business.Concrete;


public class AuthManager : IAuthService
{
    private readonly IUserService _userService;
    private readonly IEmployeeService _employeeService;
    private readonly IInstructorService _ınstructorService;

    private readonly IMapper _mapper;
    private readonly ITokenHelper _tokenHelper;

    private readonly IUserOperationClaimService _userOperationClaimService;
    private readonly IInstructorOperationClaimService _ınstructorOperationClaimService;
    private readonly IEmployeeOperationClaimService _employeeOperationClaimService;




    private readonly InstructorAuthBusinessRules _instructorAuthBusinessRules;
    private readonly AuthBusinessRules _authBusinessRules;
    private readonly EmployeeAuthBusinessRules _employeeAuthBusinessRules;

    public AuthManager(IUserService userService, IEmployeeService employeeService, IInstructorService ınstructorService, IMapper mapper, ITokenHelper tokenHelper, 
        IUserOperationClaimService userOperationClaimService, IInstructorOperationClaimService ınstructorOperationClaimService, IEmployeeOperationClaimService employeeOperationClaimService,
        InstructorAuthBusinessRules instructorAuthBusinessRules, AuthBusinessRules authBusinessRules, EmployeeAuthBusinessRules employeeAuthBusinessRules)
    {
        _userService = userService;
        _employeeService = employeeService;
        _ınstructorService = ınstructorService;
        _mapper = mapper;
        _tokenHelper = tokenHelper;
        _userOperationClaimService = userOperationClaimService;
        _ınstructorOperationClaimService = ınstructorOperationClaimService;
        _employeeOperationClaimService = employeeOperationClaimService;
        _instructorAuthBusinessRules = instructorAuthBusinessRules;
        _authBusinessRules = authBusinessRules;
        _employeeAuthBusinessRules = employeeAuthBusinessRules;
    }

    [ValidationAspect(typeof(UserForRegisterRequestValidator))]
    public async Task<AccessToken> Register(UserForRegisterRequest userForRegisterRequest, string password)
    {
        await _authBusinessRules.EmailCanNotBeDuplicatedWhenRegistered(userForRegisterRequest.Email);

        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
        UserAuth userAuth = _mapper.Map<UserAuth>(userForRegisterRequest);
        userAuth.PasswordHash = passwordHash;
        userAuth.PasswordSalt = passwordSalt;
        var createdUser = await _userService.Add(userAuth);
        
        var resultToken = await AuthCreateAccessToken(createdUser);
        await _authBusinessRules.ThrowExceptionIfCreateAccessTokenIsNull(resultToken);
        return resultToken;
    }

    public async Task<AccessToken> Login(UserForLoginRequest userForLoginRequest)
    {
        var userToCheck = await _authBusinessRules.LoginInformationCheck(userForLoginRequest);


        var result = await AuthCreateAccessToken(userToCheck);
        await _authBusinessRules.ThrowExceptionIfCreateAccessTokenIsNull(result);
        return result;
    }

    public async Task<AccessToken> AuthCreateAccessToken(UserAuth userAuth)
    {
        var claims = await _userOperationClaimService.GetClaims(userAuth.Id);
        var accessToken = await _tokenHelper.CreateToken(userAuth, claims);
        return accessToken;
    }


    public async Task<CreatedEmployeeResponse> EmployeeRegister(EmployeeForRegisterRequest employeeForRegisterRequest , string password)
    {
        await _employeeAuthBusinessRules.EmailCanNotBeDuplicatedWhenRegistered(employeeForRegisterRequest.Email);

        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
        CreateEmployeeRequest createEmployeeRequest  = _mapper.Map<CreateEmployeeRequest>(employeeForRegisterRequest);
        createEmployeeRequest.PasswordHash = passwordHash;
        createEmployeeRequest.PasswordSalt = passwordSalt;
        var createdEmployee = await _employeeService.Add(createEmployeeRequest);
        return createdEmployee;
    }

    public async Task<AccessToken> EmployeeLogin(EmployeeForLoginRequest employeeForLoginRequest)
    {
        var userToCheck = await _employeeAuthBusinessRules.LoginInformationCheck(employeeForLoginRequest);

        var result = await EmployeeCreateAccessToken(userToCheck);
        await _authBusinessRules.ThrowExceptionIfCreateAccessTokenIsNull(result);
        return result;
    }

    public async Task<AccessToken> EmployeeCreateAccessToken(UserAuth userAuth)
    {
        var claims = await _userOperationClaimService.GetClaims(userAuth.Id);
        var accessToken = await _tokenHelper.CreateToken(userAuth, claims);
        return accessToken;
    }


    public async Task<CreatedInstructorResponse> InstructorRegister(InstructorForRegisterRequest ınstructorForRegisterRequest, string password)
    {
        await _instructorAuthBusinessRules.EmailCanNotBeDuplicatedWhenRegistered(ınstructorForRegisterRequest.Email);

        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
        CreateInstructorRequest createInstructorRequest = _mapper.Map<CreateInstructorRequest>(ınstructorForRegisterRequest);
        createInstructorRequest.PasswordHash = passwordHash;
        createInstructorRequest.PasswordSalt = passwordSalt;
        var createdInstructor = await _ınstructorService.Add(createInstructorRequest);

        return createdInstructor;
    }


    public async Task<AccessToken> InstructorLogin(InstructorForLoginRequest ınstructorForLoginRequest)
    {
        var userToCheck = await _instructorAuthBusinessRules.LoginInformationCheck(ınstructorForLoginRequest);

        var result = await InstructorCreateAccessToken(userToCheck);
        await _authBusinessRules.ThrowExceptionIfCreateAccessTokenIsNull(result);
        return result;
    }
    public async Task<AccessToken> InstructorCreateAccessToken(UserAuth userAuth)
    {
        var claims = await _userOperationClaimService.GetClaims(userAuth.Id);
        var accessToken = await _tokenHelper.CreateToken(userAuth, claims);
        return accessToken;
    }
}
