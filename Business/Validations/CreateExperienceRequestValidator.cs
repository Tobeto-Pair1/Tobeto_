using Business.DTOs.Experiences;
using FluentValidation;

namespace Business.Validations;

public class CreateExperienceRequestValidator : AbstractValidator<CreateExperienceRequest>
{
    public CreateExperienceRequestValidator()
    {
        RuleFor(e => e.CompanyName).NotEmpty();
        RuleFor(e => e.PositionName).NotEmpty();
        RuleFor(e => e.SectorName).NotEmpty();


        RuleFor(e => e.CompanyName).MinimumLength(5);
        RuleFor(e => e.PositionName).MinimumLength(5);
        RuleFor(e => e.SectorName).MinimumLength(5);
    }
}
