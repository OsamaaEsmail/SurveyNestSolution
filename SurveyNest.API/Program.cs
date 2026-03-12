using SurveyNest.BuildingBlocks;
using SurveyNest.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


//DependencyInjection

builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddBuildingBlocksService(builder.Configuration);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
}



app.UseHttpsRedirection();

app.UseRateLimiter();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
