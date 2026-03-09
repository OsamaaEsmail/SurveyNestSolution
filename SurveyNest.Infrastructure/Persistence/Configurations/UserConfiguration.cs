

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveyNest.Domain.Consts;
using SurveyNest.Domain.Entities;

namespace SurveyNest.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder
            .OwnsMany(x => x.RefreshTokens)
            .ToTable("RefreshTokens") // Specify the table name for the owned entity
            .WithOwner()
            .HasForeignKey("UserId"); // Foreign key in the owned entity table








        builder.Property(p => p.FirstName).HasMaxLength(50);
        builder.Property(p => p.LastName).HasMaxLength(50);



        //step 4 add defult data by HasData

        //Default Data 
        // var passwordHasher = new PasswordHasher<ApplicationUser>();

        builder.HasData(new ApplicationUser
        {
            Id = DefaultUsers.Admin.Id,
            FirstName = "Survey Basket",
            LastName = "Admin",
            UserName = DefaultUsers.Admin.Email,
            NormalizedUserName = DefaultUsers.Admin.Email.ToUpper(),
            Email = DefaultUsers.Admin.Email,
            NormalizedEmail = DefaultUsers.Admin.Email.ToUpper(),
            SecurityStamp = DefaultUsers.Admin.SecurityStamp,
            ConcurrencyStamp = DefaultUsers.Admin.ConcurrencyStamp,
            EmailConfirmed = true,
            PasswordHash = DefaultUsers.Admin.PasswordHash,


        });








    }
}