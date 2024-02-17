using AutoMapper;
using Business.Abstract;
using Business.DTOs.Instructors;
using Business.Rules;
using Core.Entities.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;

namespace Business.Concrete;

public class AuthInstructorManager : IInstructorAuthService
{
    private readonly IInstructorService _ınstructorService;
    private readonly ITokenHelper _tokenHelper;
    private readonly IInstructorOperationClaimService _ınstructorOperationClaimService;
    private readonly IMapper _mapper;
    private readonly InstructorAuthBusinessRules _instructorAuthBusinessRules;

    public AuthInstructorManager(IInstructorService ınstructorService, ITokenHelper tokenHelper, IInstructorOperationClaimService ınstructorOperationClaimService,
        IMapper mapper, InstructorAuthBusinessRules instructorAuthBusinessRules)
    {
        _ınstructorService = ınstructorService;
        _tokenHelper = tokenHelper;
        _ınstructorOperationClaimService = ınstructorOperationClaimService;
        _mapper = mapper;
        _instructorAuthBusinessRules = instructorAuthBusinessRules;
    }

    public async Task<AccessToken> Login(InstructorForLoginRequest ınstructorForLoginRequest)
    {
        var userToCheck = await _instructorAuthBusinessRules.LoginInformationCheck(ınstructorForLoginRequest);

        var result = await CreateAccessToken(userToCheck);
        await _instructorAuthBusinessRules.ThrowExceptionIfCreateAccessTokenIsNull(result);
        return result;
    }
    public async Task<AccessToken> CreateAccessToken(UserAuth userAuth)
    {
        var claims = await _ınstructorOperationClaimService.GetClaims(userAuth.Id);
        var accessToken = await _tokenHelper.CreateToken(userAuth, claims);
        return accessToken;
    }

    public async Task<CreatedInstructorResponse> Register(InstructorForRegisterRequest ınstructorForRegisterRequest, string password)
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
}