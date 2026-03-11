

namespace SurveyNest.Application.DtoContracts.Users;

public record UserResponse
(
    string Id,
    string FirstName,
    string LastName,
    string Email,
    bool IsDisabled,
    IEnumerable<string> Roles



);