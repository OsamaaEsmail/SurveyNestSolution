using FluentValidation;
using SurveyNest.Application.DtoContracts.Authentication;

namespace SurveyNest.Application.Validators;

public class LoginValidatorRequest : AbstractValidator<LoginRequest>
{

    public LoginValidatorRequest()
    {
        RuleFor(x => x.Email).
            NotEmpty()
            .EmailAddress();


        RuleFor(x => x.Password).
            NotEmpty().
            MinimumLength(8);

    }
}