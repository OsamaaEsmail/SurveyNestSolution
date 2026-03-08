

using Microsoft.AspNetCore.Identity;

namespace SurveyNest.Domain.Entities;

public class ApplicationRole : IdentityRole
{
    public bool IsDefault { get; set; }

    public bool IsDeleted { get; set; }





}
