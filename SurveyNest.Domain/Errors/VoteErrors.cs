

using Microsoft.AspNetCore.Http;
using SurveyNest.BuildingBlocks.Abstractions;

namespace SurveyNest.Domain.Errors;

public static class VoteErrors
{
    public static readonly Error InvalidQuestionInAnswers =
        new("Vote.InvalidQuestionInAnswers", "One or more question ids in answers are invalid", StatusCodes.Status404NotFound);
    public static readonly Error DuplicatedVote =
       new("Vote.DuplicatedVote", "This user already voted before for this poll", StatusCodes.Status409Conflict);
}
