


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveyNest.Domain.Entities;

namespace SurveyNest.Infrastructure.Persistence.Configurations;

public class VoteConfiguration : IEntityTypeConfiguration<Vote>
{
    public void Configure(EntityTypeBuilder<Vote> builder)
    {
        builder.HasIndex(v => new { v.PollId, v.UserId }).IsUnique();

    }

}

