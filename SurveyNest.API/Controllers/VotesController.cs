



using SurveyNest.Application.DtoContracts.Votes;

namespace SurveyNest.API.Controllers;

[Route("api/polls/{pollId}/vote")]
[ApiController]
[Authorize(Roles = DefaultRoles.Member.Name)]
[EnableRateLimiting(RateLimiters.ConcurrencyLimiter)]
public class VotesController(IQuestionService questionService, IVoteService voteService) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> Start([FromRoute] int pollId, CancellationToken cancellationToken)
    {
        var result = await questionService.GetAllAvailableAsync(pollId, User.GetUserId()!, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpPost("")]
    public async Task<IActionResult> Vote([FromRoute] int pollId, [FromBody] VoteRequest request, CancellationToken cancellationToken)
    {
        var result = await voteService.AddAsync(pollId, User.GetUserId()!, request, cancellationToken);
        return result.IsSuccess ? Created() : result.ToProblem();
    }
}