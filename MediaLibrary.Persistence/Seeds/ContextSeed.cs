﻿using MediaLibrary.Domain.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Persistence.Seeds;

public static class ContextSeed
{

    public static void Seed(this ModelBuilder modelBuilder)
    {
        CreateRoles(modelBuilder);
        CreateBasicUsers(modelBuilder);
        MapUserRole(modelBuilder);
    }

    private static void CreateRoles(ModelBuilder modelBuilder)
    {
        List<IdentityRole> roles = DefaultRoles.IdentityRoleList();
        modelBuilder.Entity<IdentityRole>().HasData(roles);
    }

    private static void CreateBasicUsers(ModelBuilder modelBuilder)
    {
        List<ApplicationUser> users = DefaultUser.IdentityBasicUserList();
        modelBuilder.Entity<ApplicationUser>().HasData(users);
    }

    private static void MapUserRole(ModelBuilder modelBuilder)
    {
        var identityUserRoles = MappingUserRole.IdentityUserRoleList();
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(identityUserRoles);
    }
}
