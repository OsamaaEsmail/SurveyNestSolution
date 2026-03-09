

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveyNest.Domain.Entities;

namespace SurveyNest.Infrastructure.Persistence.Configurations;

public class VoteAnswerConfiguration : IEntityTypeConfiguration<VoteAnswer>
{
    public void Configure(EntityTypeBuilder<VoteAnswer> builder)
    {
        builder.HasIndex(va => new { va.VoteId, va.QuestionId }).IsUnique();

    }
}
