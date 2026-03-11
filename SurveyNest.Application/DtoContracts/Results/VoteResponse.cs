

namespace SurveyNest.Application.DtoContracts.Results;

public record VoteResponse
(
    string VoterName,
    DateTime VotedDate,
    IEnumerable<QuestionAnswerResponse> SelectedAnswers




);

