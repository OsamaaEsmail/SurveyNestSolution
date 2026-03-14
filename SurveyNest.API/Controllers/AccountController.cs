

namespace SurveyNest.API.Controllers;

[ApiVersion(1)]
[ApiVersion(2)]
[Route("me")]
[ApiController]
[Authorize]
public class AccountController(IUserService userService) : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> Info()
    {
        var result = await userService.GetProfileAsync(User.GetUserId()!);
        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpPut("info")]
    public async Task<IActionResult> UpdateInfo([FromBody] UpdateProfileRequest request)
    {
        var result = await userService.UpdateProfileAsync(User.GetUserId()!, request);
        return result.IsSuccess ? NoContent() : result.ToProblem();
    }

    [HttpPut("change-password")]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
    {
        var result = await userService.ChangePasswordAsync(User.GetUserId()!, request);
        return result.IsSuccess ? NoContent() : result.ToProblem();
    }
}