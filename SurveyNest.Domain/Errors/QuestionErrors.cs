

using Microsoft.AspNetCore.Http;
using SurveyNest.BuildingBlocks.Abstractions;

namespace SurveyNest.Domain.Errors;

public static class QuestionErrors
{
    public static readonly Error QuestionNotFound =
        new("Question.NotFound", "No question was found with the given ID", StatusCodes.Status404NotFound);

    public static readonly Error DuplicatedQuestionContent =
        new("Question.DuplicatedContent", "Another question with the same content already exists", StatusCodes.Status409Conflict);

    public static readonly Error DuplicatedQuestion =
        new("Question.DuplicatedContent", "Another question with the same content already exists", StatusCodes.Status409Conflict);
}
