


namespace SurveyNest.Application.DtoContracts.Users;

public record ChangePasswordRequest
(
    string CurrentPassword,
    string NewPassword

);