



using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SurveyNest.Infrastructure.Persistence;

namespace SurveyNest.Infrastructure;

public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services , IConfiguration configuration)
    {


        // Database
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        // HttpContext
        services.AddHttpContextAccessor();








        return services;
    }

}
