using Business.DTOs.Users;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations;

public class UserForRegisterRequestValidator : AbstractValidator<UserForRegisterRequest>
{

    public UserForRegisterRequestValidator()
    {
        RuleFor(u => u.Email).NotEmpty();
        RuleFor(u => u.Email).EmailAddress();
        RuleFor(u => u.Password).NotEmpty();
        RuleFor(u => u.PhoneNumber).Length(11);

    }
}
