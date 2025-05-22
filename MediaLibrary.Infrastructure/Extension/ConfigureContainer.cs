//using MediaLibrary.Application.Interfaces;
//using MediaLibrary.Domain.Auth;
//using MediaLibrary.Persistence;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MediaLibrary.Infrastructure.Extension;

//public static class ConfigureContainer
//{
//    public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
//    {
//        services.AddDbContext<RepositoryDbContext>(options =>
//            options.UseSqlite(
//                configuration.GetConnectionString("DefaultConnection"),
//                b => b.MigrationsAssembly(typeof(RepositoryDbContext).Assembly.FullName)));
//    }

//    public static void AddScopedServices(this IServiceCollection services)
//    {
//        services.AddScoped<IRepositoryDbContext, RepositoryDbContext>();
//    }
//}
