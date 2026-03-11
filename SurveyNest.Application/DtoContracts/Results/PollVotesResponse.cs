



namespace SurveyNest.Application.DtoContracts.Results;

public record PollVotesResponse
(
    string Title,
    IEnumerable<VoteResponse> Votes






);