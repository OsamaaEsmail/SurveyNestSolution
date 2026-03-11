

namespace SurveyNest.Application.DtoContracts.Results;

public record VotesPerQuestionResponse(
    string Question,
    IEnumerable<VotesPerAnswerResponse> SelectedAnswers
);