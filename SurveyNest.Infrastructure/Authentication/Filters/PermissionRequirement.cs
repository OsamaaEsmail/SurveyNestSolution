

using Microsoft.AspNetCore.Authorization;

namespace SurveyNest.Infrastructure.Authentication.Filters;

public class PermissionRequirement(string permission) : IAuthorizationRequirement
{
    public string Permission { get; } = permission;
}
