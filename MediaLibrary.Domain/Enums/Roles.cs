using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Domain.Enums;

public enum Roles
{

    SuperAdmin,
    Admin,
    Moderator,
    Basic
}

public static class RolesConstants
{
    public static readonly string SuperAdmin = Guid.NewGuid().ToString();
    public static readonly string Admin = Guid.NewGuid().ToString();
    public static readonly string Moderator = Guid.NewGuid().ToString();
    public static readonly string Basic = Guid.NewGuid().ToString();

    public static readonly string SuperAdminUser = Guid.NewGuid().ToString();
    public static readonly string BasicUser = Guid.NewGuid().ToString();
}
