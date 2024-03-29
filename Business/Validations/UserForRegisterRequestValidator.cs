using Business.DTOs.Auths;
using FluentValidation;

namespace Business.Validations;

public class UserForRegisterRequestValidator : AbstractValidator<UserForRegisterRequest>
{
    public UserForRegisterRequestValidator()
    {
        RuleFor(u => u.Email).NotEmpty();
        RuleFor(u => u.Email).EmailAddress();
        RuleFor(u => u.Password).NotEmpty();
        RuleFor(u => u.Password).MinimumLength(6);
        RuleFor(u => u.PhoneNumber).Length(11);
    }
}
