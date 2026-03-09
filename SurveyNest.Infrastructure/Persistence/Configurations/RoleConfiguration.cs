

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveyNest.Domain.Consts;
using SurveyNest.Domain.Entities;

namespace SurveyNest.Infrastructure.Persistence.Configurations;


public class RoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
{

    // step 5 add seed defult Roles data 

    public void Configure(EntityTypeBuilder<ApplicationRole> builder)
    {


        builder.HasData([
            new ApplicationRole
            {
                Id =DefaultRoles.Admin.Id,
                Name = DefaultRoles.Admin.Name,
                NormalizedName = DefaultRoles.Admin.Name.ToUpper(),
                ConcurrencyStamp=DefaultRoles.Admin.ConcurrencyStamp


            },

             new ApplicationRole
             {
                Id =DefaultRoles.Member.Id,
                Name = DefaultRoles.Member.Name,
                NormalizedName = DefaultRoles.Member.Name.ToUpper(),
                ConcurrencyStamp=DefaultRoles.Member.ConcurrencyStamp,
                IsDefault = true


             }


        ]);






    }


}
