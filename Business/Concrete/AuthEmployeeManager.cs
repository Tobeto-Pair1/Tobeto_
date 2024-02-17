using AutoMapper;
using Business.Abstract;
using Business.DTOs.Employees;
using Business.Rules;
using Core.Entities.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;


namespace Business.Concrete;

public class AuthEmployeeManager : IEmployeeAuthService
{
    private readonly IEmployeeService _employeeService;
    private readonly ITokenHelper _tokenHelper;
    private readonly IEmployeeOperationClaimService _employeeOperationClaimService;
    private readonly IMapper _mapper;
    private readonly EmployeeAuthBusinessRules _adminAuthBusinessRules;

    public AuthEmployeeManager(IEmployeeService employeeService, ITokenHelper tokenHelper, IEmployeeOperationClaimService employeeOperationClaimService,
        IMapper mapper, EmployeeAuthBusinessRules adminAuthBusinessRules)
    {
        _employeeService = employeeService;
        _tokenHelper = tokenHelper;
        _employeeOperationClaimService = employeeOperationClaimService;
        _mapper = mapper;
        _adminAuthBusinessRules = adminAuthBusinessRules;
    }

    public async Task<AccessToken> Login(EmployeeForLoginRequest employeeForLoginRequest)
    {
        var userToCheck = await _adminAuthBusinessRules.LoginInformationCheck(employeeForLoginRequest);

        var result = await CreateAccessToken(userToCheck);
        await _adminAuthBusinessRules.ThrowExceptionIfCreateAccessTokenIsNull(result);
        return result;
    }

    public async Task<CreatedEmployeeResponse> Register(EmployeeForRegisterRequest employeeForRegisterRequest, string password)
    {
        await _adminAuthBusinessRules.EmailCanNotBeDuplicatedWhenRegistered(employeeForRegisterRequest.Email);

        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
        CreateEmployeeRequest createEmployeeRequest = _mapper.Map<CreateEmployeeRequest>(employeeForRegisterRequest);
        createEmployeeRequest.PasswordHash = passwordHash;
        createEmployeeRequest.PasswordSalt = passwordSalt;
        var createdEmployee = await _employeeService.Add(createEmployeeRequest);

        return createdEmployee;
    }

    public async Task<AccessToken> CreateAccessToken(UserAuth userAuth)
    {
        var claims = await _employeeOperationClaimService.GetClaims(userAuth.Id);
        var accessToken = await _tokenHelper.CreateToken(userAuth, claims);
        return accessToken;
    }

}
