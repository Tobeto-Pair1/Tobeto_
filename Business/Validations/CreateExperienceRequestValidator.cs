using Business.DTOs.Experiences;
using FluentValidation;

namespace Business.Validations;

public class CreateExperienceRequestValidator : AbstractValidator<CreateExperienceRequest>
{
    public CreateExperienceRequestValidator()
    {
        RuleFor(e => e.CompanyName).NotEmpty().WithMessage("Doldurulması zorunlu alan");
        RuleFor(e => e.PositionName).NotEmpty().WithMessage("Doldurulması zorunlu alan");
        RuleFor(e => e.SectorName).NotEmpty().WithMessage("Doldurulması zorunlu alan");


        RuleFor(e => e.CompanyName).MinimumLength(2).WithMessage("En az 5 karakter girmelisiniz");
        RuleFor(e => e.PositionName).MinimumLength(2).WithMessage("En az 5 karakter girmelisiniz");
        RuleFor(e => e.SectorName).MinimumLength(2).WithMessage("En az 5 karakter girmelisiniz");
    }
}
