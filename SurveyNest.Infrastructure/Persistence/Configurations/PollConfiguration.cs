



using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveyNest.Domain.Entities;

namespace SurveyNest.Infrastructure.Persistence.Configurations;

public class PollConfiguration : IEntityTypeConfiguration<Poll>
{
    public void Configure(EntityTypeBuilder<Poll> builder)
    {
        builder.HasIndex(x => x.Title).IsUnique();
        builder.Property(p => p.Title).HasMaxLength(100);
        builder.Property(p => p.Summary).HasMaxLength(500);

    }
}
