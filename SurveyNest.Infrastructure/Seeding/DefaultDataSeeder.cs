

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SurveyNest.Domain.Entities;
using SurveyNest.Infrastructure.Persistence;

namespace SurveyNest.Infrastructure.Seeding;

public class DefaultDataSeeder(
    ApplicationDbContext context,
    ILogger<DefaultDataSeeder> logger)
{
    public async Task SeedAsync()
    {
        if (await context.Polls.AnyAsync())
        {
            logger.LogInformation("Seed data already exists, skipping.");
            return;
        }

        var polls = new List<Poll>
        {
            new()
            {
                Title = "Customer Satisfaction Survey",
                Summary = "Help us improve our services by sharing your experience.",
                IsPublished = true,
                StartsAt = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(-10)),
                EndsAt = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(20)),
                CreatedById = DefaultUsers.Admin.Id,
                CreatedOn = DateTime.UtcNow.AddDays(-10),

                Questions =
                [
                    new Question
                    {
                        Content = "How satisfied are you with our service overall?",
                        IsActive = true,
                        Answers =
                        [
                            new Answer { Content = "Very Satisfied", IsActive = true },
                            new Answer { Content = "Satisfied", IsActive = true },
                            new Answer { Content = "Neutral", IsActive = true },
                            new Answer { Content = "Dissatisfied", IsActive = true },
                            new Answer { Content = "Very Dissatisfied", IsActive = true }
                        ]
                    },
                    new Question
                    {
                        Content = "How likely are you to recommend us to a friend?",
                        IsActive = true,
                        Answers =
                        [
                            new Answer { Content = "Definitely Would", IsActive = true },
                            new Answer { Content = "Probably Would", IsActive = true },
                            new Answer { Content = "Not Sure", IsActive = true },
                            new Answer { Content = "Probably Would Not", IsActive = true },
                            new Answer { Content = "Definitely Would Not", IsActive = true }
                        ]
                    },
                    new Question
                    {
                        Content = "How would you rate our response time?",
                        IsActive = true,
                        Answers =
                        [
                            new Answer { Content = "Excellent", IsActive = true },
                            new Answer { Content = "Good", IsActive = true },
                            new Answer { Content = "Average", IsActive = true },
                            new Answer { Content = "Poor", IsActive = true }
                        ]
                    }
                ]
            },

            new()
            {
                Title = "Product Feedback Survey",
                Summary = "Tell us what you think about our latest product.",
                IsPublished = true,
                StartsAt = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(-5)),
                EndsAt = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(25)),
                CreatedById = DefaultUsers.Admin.Id,
                CreatedOn = DateTime.UtcNow.AddDays(-5),

                Questions =
                [
                    new Question
                    {
                        Content = "How would you rate the product quality?",
                        IsActive = true,
                        Answers =
                        [
                            new Answer { Content = "Outstanding", IsActive = true },
                            new Answer { Content = "Good", IsActive = true },
                            new Answer { Content = "Fair", IsActive = true },
                            new Answer { Content = "Poor", IsActive = true }
                        ]
                    },
                    new Question
                    {
                        Content = "Was the product easy to use?",
                        IsActive = true,
                        Answers =
                        [
                            new Answer { Content = "Very Easy", IsActive = true },
                            new Answer { Content = "Easy", IsActive = true },
                            new Answer { Content = "Difficult", IsActive = true },
                            new Answer { Content = "Very Difficult", IsActive = true }
                        ]
                    }
                ]
            },

            new()
            {
                Title = "Employee Engagement Survey",
                Summary = "Annual survey to measure employee satisfaction.",
                IsPublished = false,
                StartsAt = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(5)),
                EndsAt = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(35)),
                CreatedById = DefaultUsers.Admin.Id,
                CreatedOn = DateTime.UtcNow,

                Questions =
                [
                    new Question
                    {
                        Content = "How satisfied are you with your work environment?",
                        IsActive = true,
                        Answers =
                        [
                            new Answer { Content = "Very Satisfied", IsActive = true },
                            new Answer { Content = "Satisfied", IsActive = true },
                            new Answer { Content = "Neutral", IsActive = true },
                            new Answer { Content = "Dissatisfied", IsActive = true }
                        ]
                    }
                ]
            }
        };

        await context.Polls.AddRangeAsync(polls);
        await context.SaveChangesAsync();

        logger.LogInformation("Seed data inserted successfully.");
    }
}