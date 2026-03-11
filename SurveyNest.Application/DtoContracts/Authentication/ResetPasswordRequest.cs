


namespace SurveyNest.Application.DtoContracts.Authentication;

public record ResetPasswordRequest
(
    string Email,
    string Code,
    string NewPassword
);
