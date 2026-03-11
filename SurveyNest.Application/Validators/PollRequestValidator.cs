using FluentValidation;
using SurveyNest.Application.DtoContracts.Polls;

namespace SurveyNest.Application.Validators;


public class PollRequestValidator : AbstractValidator<PollRequest>
{
    public PollRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("please add a {PropertyName}")
            .Length(3, 100)
            .WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters");


        RuleFor(x => x.Summary)
            .NotEmpty()
            .WithMessage("please add a {PropertyName}")
            .Length(10, 500)
            .WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters");


        RuleFor(x => x.StartsAt)
            .NotEmpty()
            .WithMessage("please add a {PropertyName}")
            .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today))
            .WithMessage("{PropertyName} must be greater than or equal to today");

        RuleFor(x => x.EndsAt)
            .NotEmpty();

        RuleFor(x => x)
            .Must(HasValidDates)
            .WithName(nameof(PollRequest.EndsAt))
            .WithMessage("{PropertyName}must be greater than or equal to StartsAt");





    }

    private bool HasValidDates(PollRequest pollRequest)
    {
        return pollRequest.EndsAt >= pollRequest.StartsAt;
    }


}
