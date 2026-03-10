

using Microsoft.AspNetCore.Authorization;

namespace SurveyNest.Infrastructure.Authentication.Filters;

public class HasPermissionAttribute(string permission) : AuthorizeAttribute(permission)
{


}