using FluentValidation;
using SurveyNest.Application.DtoContracts.Authentication;

namespace SurveyNest.Application.Validators;

public class ResendConfirmationEmailRequestValidator : AbstractValidator<ResendConfirmationEmailRequest>
{
    public ResendConfirmationEmailRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();



    }
}

