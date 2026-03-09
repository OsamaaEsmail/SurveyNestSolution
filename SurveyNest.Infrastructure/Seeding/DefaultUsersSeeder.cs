

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SurveyNest.Domain.Consts;
using SurveyNest.Domain.Entities;

namespace SurveyNest.Infrastructure.Seeding;

public class DefaultUsersSeeder(
    UserManager<ApplicationUser> userManager,
    ILogger<DefaultUsersSeeder> logger)
{
    public async Task SeedAsync()
    {
        if (await userManager.FindByIdAsync(DefaultUsers.Admin.Id) is null)
        {
            await userManager.CreateAsync(DefaultUsers.Admin);
            await userManager.AddToRoleAsync(DefaultUsers.Admin, DefaultRoles.Admin.Name);
            logger.LogInformation("Admin user seeded.");
        }
    }
}
