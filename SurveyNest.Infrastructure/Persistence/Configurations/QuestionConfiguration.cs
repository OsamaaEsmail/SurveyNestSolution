



using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveyNest.Domain.Entities;

namespace SurveyNest.Infrastructure.Persistence.Configurations;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.HasIndex(x => new { x.PollId, x.Content }).IsUnique();

        builder.Property(x => x.Content).HasMaxLength(1000);
    }
}
