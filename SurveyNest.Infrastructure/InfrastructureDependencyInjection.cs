



using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SurveyNest.Application.Interfaces;
using SurveyNest.Domain.Entities;
using SurveyNest.Infrastructure.Authentication;
using SurveyNest.Infrastructure.Persistence;
using SurveyNest.Infrastructure.Seeding;
using SurveyNest.Infrastructure.Services;
using SurveyNest.Infrastructure.Settings;
using System.Text;

namespace SurveyNest.Infrastructure;

public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {


        // Database
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        // HttpContext
        services.AddHttpContextAccessor();


        // Application Services

       

        services.AddOptions<MailSettings>()
            .BindConfiguration(nameof(MailSettings))
            .ValidateDataAnnotations()
            .ValidateOnStart();


        //TO Do Infrecess
        // Application Services
        services.AddScoped<IPollService, PollService>();
        services.AddScoped<IQuestionService, QuestionService>();
        services.AddScoped<IVoteService, VoteService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IResultService, ResultService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<INotificationService, NotificationService>();
        services.AddScoped<IEmailSender, EmailService>();

        // Seeders
        services.AddScoped<DefaultRolesSeeder>();
        services.AddScoped<DefaultUsersSeeder>();
        services.AddScoped<DefaultDataSeeder>();


        services.AddAuthIdentityConfig(configuration)
         .AddJwtConfig(configuration);
        


        return services;


    } 


    //==================================Privte Methods======================================//

    private static IServiceCollection AddAuthIdentityConfig(this IServiceCollection services, IConfiguration configuration)
    {
        // Identity
        services
            .AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.SignIn.RequireConfirmedEmail = false;
                options.User.RequireUniqueEmail = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
        return services;


    }



    private static IServiceCollection AddJwtConfig(this IServiceCollection services, IConfiguration configuration)
    {
      
        services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.SectionName));

        var jwtSettings = configuration.GetSection(JwtOptions.SectionName).Get<JwtOptions>();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(o =>
        {
            o.SaveToken = true;
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings?.Key!)),
                ValidIssuer = jwtSettings?.Issuer,
                ValidAudience = jwtSettings?.Audience
            };
        });

        services.AddSingleton<IJwtProvider, JwtProvider>();
        return services;
    }








}
