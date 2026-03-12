



using SurveyNest.Application.DtoContracts.Polls;
using SurveyNest.BuildingBlocks.Abstractions;

namespace SurveyNest.Application.Interfaces;

public interface IPollService
{
  
    Task<Result<IEnumerable<PollResponse>>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<Result<IEnumerable<PollResponse>>> GetCurrentAsyncV1(CancellationToken cancellationToken = default);

  
    Task<Result<IEnumerable<PollResponseV2>>> GetCurrentAsyncV2(CancellationToken cancellationToken = default);

    Task<Result<PollResponse>> GetAsync(int id, CancellationToken cancellationToken = default);
    Task<Result<PollResponse>> AddAsync(PollRequest request, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(int id, PollRequest request, CancellationToken cancellationToken = default);
    Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default);
    Task<Result> TogglePublishStatusAsync(int id, CancellationToken cancellationToken = default);
}
