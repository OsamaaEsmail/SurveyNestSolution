


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveyNest.Domain.Entities;

namespace SurveyNest.Infrastructure.Persistence.Configurations;

public class AnswerConfigurations : IEntityTypeConfiguration<Answer> // Fluent API Configurations
{
    public void Configure(EntityTypeBuilder<Answer> builder)
    {
        builder.HasIndex(x => new {x.QuestionId, x.Content}).IsUnique();

        builder.Property(x => x.Content).HasMaxLength(1000);

    }
}
