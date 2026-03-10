



using Microsoft.AspNetCore.Http;
using SurveyNest.BuildingBlocks.Abstractions;

namespace SurveyNest.Domain.Errors;

public static class PollErrors
{
    public static readonly Error PollNotFound =
        new("poll.NotFound", "No poll was found with the given ID", StatusCodes.Status404NotFound);

    public static readonly Error DuplicatedPollTitle =
        new("poll.DuplicatedTitle", "Another poll with the same title already exists", StatusCodes.Status409Conflict);
}
