

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SurveyNest.Domain.Consts;
using SurveyNest.Domain.Entities;

namespace SurveyNest.Infrastructure.Seeding;

public class DefaultRolesSeeder(
    RoleManager<ApplicationRole> roleManager,
    ILogger<DefaultRolesSeeder> logger)
{
    public async Task SeedAsync()
    {
        var roles = new List<ApplicationRole>
        {
            new()
            {
                Id               = DefaultRoles.Admin.Id,
                Name             = DefaultRoles.Admin.Name,
                NormalizedName   = DefaultRoles.Admin.Name.ToUpper(),
                ConcurrencyStamp = DefaultRoles.Admin.ConcurrencyStamp,
                IsDefault        = false
            },
            new()
            {
                Id               = DefaultRoles.Member.Id,
                Name             = DefaultRoles.Member.Name,
                NormalizedName   = DefaultRoles.Member.Name.ToUpper(),
                ConcurrencyStamp = DefaultRoles.Member.ConcurrencyStamp,
                IsDefault        = true
            }
        };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role.Name!))
            {
                await roleManager.CreateAsync(role);
                logger.LogInformation("Role {Role} has been seeded.", role.Name);
            }
        }
    }
}
