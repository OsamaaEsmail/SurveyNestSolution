


namespace SurveyNest.API.Controllers;

[Route("[controller]")]
[ApiController]
[EnableRateLimiting(RateLimiters.IpLimiter)]
public class AuthController(IAuthService authService, ILogger<AuthController> logger) : ControllerBase
{
    [HttpPost("")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Login attempt for email: {email}", request.Email);
        var result = await authService.GetTokenAsync(request.Email, request.Password, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpPost("register")]
    [DisableRateLimiting]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request, CancellationToken cancellationToken)
    {
        var result = await authService.RegisterAsync(request, cancellationToken);
        return result.IsSuccess ? Ok() : result.ToProblem();
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshAsync([FromBody] RefreshTokenRequest request, CancellationToken cancellationToken)
    {
        var result = await authService.GetRefreshTokenAsync(request.Token, request.RefreshToken, cancellationToken);
        return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
    }

    [HttpPost("revoke-refresh-token")]
    public async Task<IActionResult> RevokeRefreshTokenAsync([FromBody] RefreshTokenRequest request, CancellationToken cancellationToken)
    {
        var result = await authService.RevokeRefreshTokenAsync(request.Token, request.RefreshToken, cancellationToken);
        return result.IsSuccess ? Ok() : result.ToProblem();
    }

    [HttpPost("confirm-email")]
    public async Task<IActionResult> ConfirmEmailAsync([FromBody] ConfirmEmailRequest request)
    {
        var result = await authService.ConfirmEmailAsync(request);
        return result.IsSuccess ? Ok() : result.ToProblem();
    }

    [HttpPost("resend-confirmation-email")]
    public async Task<IActionResult> ResendConfirmationEmail([FromBody] ResendConfirmationEmailRequest request)
    {
        var result = await authService.ResendConfirmationEmailAsync(request);
        return result.IsSuccess ? Ok() : result.ToProblem();
    }

    [HttpPost("forget-password")]
    public async Task<IActionResult> ForgetPassword([FromBody] ForgetPasswordRequest request)
    {
        var result = await authService.SendResetPasswordCodeAsync(request.Email);
        return result.IsSuccess ? Ok() : result.ToProblem();
    }

    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
    {
        var result = await authService.ResetPasswordAsync(request);
        return result.IsSuccess ? Ok() : result.ToProblem();
    }
}