using Core.CrossCuttingConcerns.Exceptions.Types;
using FluentValidation;
using ValidationException = Core.CrossCuttingConcerns.Exceptions.Types.ValidationException;

namespace Core.CrossCuttingConcrens.Validation;

public static class ValidationTool
{
    public static void Validate(IValidator validator, object entity)
    {
        var context = new ValidationContext<object>(entity);
        var result = validator.Validate(context);

        if (!result.IsValid)
        {
            var errors = result.Errors.GroupBy(
                  keySelector: p => p.PropertyName,
                  resultSelector: (propertyName, errors) =>
                     new ValidationExceptionModel { Property = propertyName, Errors = errors.Select(e => e.ErrorMessage) }
               ).ToList();
            throw new ValidationException(errors);
        }
    }
}