//using Business.Abstract;
//using Business.DTOs.Instructors;
//using Business.DTOs.Users;
//using Business.Messages;
//using Core.Business;
//using Core.CrossCuttingConcerns.Exceptions.Types;
//using Core.Entities.Concrete;
//using Core.Utilities.Security.Hashing;
//using Core.Utilities.Security.JWT;


//namespace Business.Rules;

//public class InstructorBusinessRules : BaseBusinessRules
//{
//    private readonly IInstructorService _ınstructorService;

//    public InstructorBusinessRules(IInstructorService ınstructorService)
//    {
//        _ınstructorService = ınstructorService;
//    }

//    public async Task EmailCanNotBeDuplicatedWhenRegistered(string email)
//    {
//        var userToCheck = await _ınstructorService.GetByMail(email);
//        if (userToCheck != null) throw new BusinessException(BusinessMessages.UserAlreadyExists);
//    }
//    public async Task<UserAuth> LoginInformationCheck(InstructorForLoginRequest ınstructorForLoginRequest)
//    {
//        var userToCheck = await _ınstructorService.GetByMail(ınstructorForLoginRequest.Email);
//        if (userToCheck == null)
//        {
//            throw new BusinessException(BusinessMessages.UserNotFound);
//        }
//        if (!HashingHelper.VerifyPasswordHash(ınstructorForLoginRequest.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
//        {
//            throw new BusinessException(BusinessMessages.PasswordError);
//        }
//        return userToCheck;
//    }
//    public Task ThrowExceptionIfCreateAccessTokenIsNull(AccessToken accessToken)
//    {
//        if (accessToken == null)
//            throw new BusinessException(BusinessMessages.CreateAccessTokenNot);
//        return Task.CompletedTask;
//    }
//}