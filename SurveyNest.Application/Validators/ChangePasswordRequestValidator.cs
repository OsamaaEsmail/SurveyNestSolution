using FluentValidation;
using SurveyNest.Application.DtoContracts.Users;
using SurveyNest.Domain.Consts;

namespace SurveyNest.Application.Validators;

public class ChangePasswordRequestValidator : AbstractValidator<ChangePasswordRequest>
{
    public ChangePasswordRequestValidator()
    {
        RuleFor(x => x.CurrentPassword)
            .NotEmpty();




        RuleFor(x => x.NewPassword)
            .NotEmpty().WithMessage("Password is required.")
            .Matches(RegexPatterns.Password)
            .WithMessage("Password must be at least 8 digits and Should contains Lowercase .")
            .NotEqual(x => x.CurrentPassword)
            .WithMessage("New Password Cannot be Same as The CurrentPassword ");


    }


}