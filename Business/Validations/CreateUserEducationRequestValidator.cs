using Business.DTOs.UserEducations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations;

public class CreateUserEducationRequestValidator : AbstractValidator<CreateUserEducationRequest>
{
    public CreateUserEducationRequestValidator()
    {
        RuleFor(e => e.EducationType).NotEmpty();
        RuleFor(e => e.University).NotEmpty();
        RuleFor(e => e.Department).NotEmpty();
        RuleFor(e => e.StartDate).NotEmpty();
        RuleFor(e => e.GraduationDate).NotEmpty();


        RuleFor(e => e.University).MinimumLength(2);
        RuleFor(e => e.University).MinimumLength(2);
        RuleFor(e => e.Department).MinimumLength(2);

    }
}
