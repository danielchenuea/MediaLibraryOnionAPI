using MediaLibrary.Application.Interfaces;
using MediaLibrary.Domain.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Persistence;

public static class DependencyInjection
{
    public static void AddRepositoryContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<RepositoryDbContext>(options =>
            options.UseSqlite(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(RepositoryDbContext).Assembly.FullName)));

        services.AddScoped<IRepositoryDbContext, RepositoryDbContext>();
    }

    public static void AddIdentityContext(this IServiceCollection services, IConfiguration configuration)
    {   
        services.AddDbContext<IdentityContext>(options =>
            options.UseSqlite(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName)));

        services
            .AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<IdentityContext>()
            .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>(TokenOptions.DefaultProvider);
    }
}
