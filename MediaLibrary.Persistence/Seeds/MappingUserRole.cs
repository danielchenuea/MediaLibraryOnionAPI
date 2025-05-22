using MediaLibrary.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Persistence.Seeds;

public static class MappingUserRole
{
    public static List<IdentityUserRole<string>> IdentityUserRoleList(){

        return new List<IdentityUserRole<string>>()
            {
                new()
                {
                    RoleId = RolesConstants.Basic,
                    UserId = RolesConstants.BasicUser
                },
                new()
                {
                    RoleId = RolesConstants.SuperAdmin,
                    UserId = RolesConstants.SuperAdminUser
                },
                new()
                {
                    RoleId = RolesConstants.Admin,
                    UserId = RolesConstants.SuperAdminUser
                },
                new()
                {
                    RoleId = RolesConstants.Moderator,
                    UserId = RolesConstants.SuperAdminUser
                },
                new()
                {
                    RoleId = RolesConstants.Basic,
                    UserId = RolesConstants.SuperAdminUser
                }
            };
    }
}
