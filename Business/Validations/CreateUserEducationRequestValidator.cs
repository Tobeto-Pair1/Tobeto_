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
        RuleFor(e => e.EducationType).NotEmpty().WithMessage("Doldurulması zorunlu alan");
        RuleFor(e => e.University).NotEmpty().WithMessage("Doldurulması zorunlu alan");
        RuleFor(e => e.Department).NotEmpty().WithMessage("Doldurulması zorunlu alan");
        RuleFor(e => e.StartDate).NotEmpty().WithMessage("Doldurulması zorunlu alan");
        RuleFor(e => e.GraduationDate).NotEmpty().WithMessage("Doldurulması zorunlu alan");


        RuleFor(e => e.University).MinimumLength(2).WithMessage("En az 2 karakter girmelisiniz");
        RuleFor(e => e.University).MinimumLength(2).WithMessage("En az 2 karakter girmelisiniz");
        RuleFor(e => e.Department).MinimumLength(2).WithMessage("En az 2 karakter girmelisiniz");

    }
}
