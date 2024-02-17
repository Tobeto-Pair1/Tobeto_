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

    private readonly IMapper _mapper;
    private readonly ITokenHelper _tokenHelper;

    private readonly IUserOperationClaimService _userOperationClaimService;

    private readonly AuthBusinessRules _authBusinessRules;

    public AuthManager(IUserService userService, IMapper mapper, ITokenHelper tokenHelper, IUserOperationClaimService userOperationClaimService,  AuthBusinessRules authBusinessRules)
    {
        _userService = userService;
        _mapper = mapper;
        _tokenHelper = tokenHelper;
        _userOperationClaimService = userOperationClaimService;
        _authBusinessRules = authBusinessRules;
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
        
        var resultToken = await CreateAccessToken(createdUser);
        await _authBusinessRules.ThrowExceptionIfCreateAccessTokenIsNull(resultToken);
        return resultToken;
    }

    public async Task<AccessToken> Login(UserForLoginRequest userForLoginRequest)
    {
        var userToCheck = await _authBusinessRules.LoginInformationCheck(userForLoginRequest);


        var result = await CreateAccessToken(userToCheck);
        await _authBusinessRules.ThrowExceptionIfCreateAccessTokenIsNull(result);
        return result;
    }

    public async Task<AccessToken> CreateAccessToken(UserAuth userAuth)
    {
        var claims = await _userOperationClaimService.GetClaims(userAuth.Id);
        var accessToken = await _tokenHelper.CreateToken(userAuth, claims);
        return accessToken;
    }
}
