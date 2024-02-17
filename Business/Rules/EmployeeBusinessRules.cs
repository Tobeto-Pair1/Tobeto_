//using Business.Abstract;
//using Business.DTOs.Employees;
//using Business.DTOs.Users;
//using Business.Messages;
//using Core.Business;
//using Core.CrossCuttingConcerns.Exceptions.Types;
//using Core.Entities.Concrete;
//using Core.Utilities.Security.Hashing;
//using Core.Utilities.Security.JWT;


//namespace Business.Rules;

//public class EmployeeBusinessRules : BaseBusinessRules
//{
//    private readonly IEmployeeService _employeeService;

//    public EmployeeBusinessRules(IEmployeeService employeeService)
//    {
//        _employeeService = employeeService;
//    }


//    public async Task EmailCanNotBeDuplicatedWhenRegistered(string email)
//    {
//        var userToCheck = await _employeeService.GetByMail(email);
//        if (userToCheck != null) throw new BusinessException(BusinessMessages.UserAlreadyExists);
//    }

//    public async Task<UserAuth> LoginInformationCheck(EmployeeForLoginRequest employeeForLoginRequest)
//    {
//        var userToCheck = await _employeeService.GetByMail(employeeForLoginRequest.Email);
//        if (userToCheck == null)
//        {
//            throw new BusinessException(BusinessMessages.UserNotFound);
//        }
//        if (!HashingHelper.VerifyPasswordHash(employeeForLoginRequest.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
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