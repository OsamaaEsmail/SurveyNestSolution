

using SurveyNest.Application.DtoContracts.Votes;
using SurveyNest.BuildingBlocks.Abstractions;

namespace SurveyNest.Application.Interfaces;

public interface IVoteService
{
    Task<Result> AddAsync(int pollId, string userId, VoteRequest request, CancellationToken cancellationToken = default);
}
