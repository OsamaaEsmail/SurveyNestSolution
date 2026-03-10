

using SurveyNest.Domain.Entities;

namespace SurveyNest.Application.Interfaces;

public interface IJwtProvider
{
    (string token, int expiresIn) GenerateToken(ApplicationUser user, IEnumerable<string> roles, IEnumerable<string> permissions);

    string? ValidateToken(string token);
}
