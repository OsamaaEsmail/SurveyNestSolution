
using SurveyNest.Domain.Entities;

namespace SurveyNest.Infrastructure.Seeding;

public static class DefaultUsers
{
    public static readonly ApplicationUser Admin = new()
    {
        Id = Domain.Consts.DefaultUsers.Admin.Id,
        UserName = Domain.Consts.DefaultUsers.Admin.Email,
        Email = Domain.Consts.DefaultUsers.Admin.Email,
        NormalizedEmail = Domain.Consts.DefaultUsers.Admin.Email.ToUpper(),
        NormalizedUserName = Domain.Consts.DefaultUsers.Admin.Email.ToUpper(),
        EmailConfirmed = true,
        IsDisabled = false,
        SecurityStamp = Domain.Consts.DefaultUsers.Admin.SecurityStamp,
        ConcurrencyStamp = Domain.Consts.DefaultUsers.Admin.ConcurrencyStamp,
        PasswordHash = Domain.Consts.DefaultUsers.Admin.PasswordHash,
        FirstName = "Survey",
        LastName = "Admin"
    };
}
