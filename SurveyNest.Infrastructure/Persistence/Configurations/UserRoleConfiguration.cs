

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveyNest.Domain.Consts;

namespace SurveyNest.Infrastructure.Persistence.Configurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{


    // step 5 add seed defult Roles data 
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {


        builder.HasData(new IdentityUserRole<string>
        {

            UserId = DefaultUsers.Admin.Id,
            RoleId = DefaultRoles.Admin.Id



        });









    }


}