using FluentValidation;
using SurveyNest.Application.DtoContracts.Authentication;

namespace SurveyNest.Application.Validators;

public class RefreshTokenRequestValidator : AbstractValidator<RefreshTokenRequest>
{
    public RefreshTokenRequestValidator()
    {
        RuleFor(x => x.Token).NotEmpty();


        RuleFor(x => x.RefreshToken).NotEmpty();

    }




}
