using FluentValidation;
using SurveyNest.Application.DtoContracts.Authentication;
using SurveyNest.Domain.Consts;

namespace SurveyNest.Application.Validators;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress()
            .WithMessage("Invalid email format.");



        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .Matches(RegexPatterns.Password).WithMessage("Password must be at least 8 digits and Should contains Lowercase .");



        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .Length(4, 50).WithMessage("First name must be between 2 and 50 characters.");




        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .Length(4, 50).WithMessage("Last name must be between 2 and 50 characters.");


    }


}
