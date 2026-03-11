using FluentValidation;
using SurveyNest.Application.DtoContracts.Authentication;

namespace SurveyNest.Application.Validators;

public class ConfirmEmailRequestValidator : AbstractValidator<ConfirmEmailRequest>
{
    public ConfirmEmailRequestValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required.");


        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Code is required.");


    }
}
