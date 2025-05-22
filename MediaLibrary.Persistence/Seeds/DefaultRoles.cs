using MediaLibrary.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Persistence.Seeds;

public static class DefaultRoles
{
    public static List<IdentityRole> IdentityRoleList()
    {
        return new List<IdentityRole>()
        {
            new()
            {
                Id = RolesConstants.SuperAdmin,
                Name = Roles.SuperAdmin.ToString(),
                NormalizedName = Roles.SuperAdmin.ToString().ToUpper(),
            },
            new()
            {
                Id = RolesConstants.Admin,
                Name = Roles.Admin.ToString(),
                NormalizedName = Roles.Admin.ToString().ToUpper(),
            },
            new()
            {
                Id = RolesConstants.Moderator,
                Name = Roles.Moderator.ToString(),
                NormalizedName = Roles.Moderator.ToString().ToUpper(),
            },
            new()
            {
                Id = RolesConstants.Basic,
                Name = Roles.Basic.ToString(),
                NormalizedName = Roles.Basic.ToString().ToUpper(),
            },
        };
    }
}
