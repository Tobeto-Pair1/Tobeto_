using Business.DTOs.Users;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations;

public class LoginValidate : AbstractValidator<UserForLoginRequest>
{

    public LoginValidate()
    {
        RuleFor(o => o.Email).NotEmpty();
        //RuleFor(o => o.Email).MinimumLength(6);
        //RuleFor(p => p.Password).NotEmpty();
        //RuleFor(p => p.Password).Matches("[A-Z]");
        //RuleFor(p => p.Password).Matches("[a-z]");
        //RuleFor(p => p.Password).Matches("[0-9]");
        //RuleFor(p => p.Password).Matches("[^a-zA-z0-9]");
    }
}
