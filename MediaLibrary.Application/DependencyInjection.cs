using FluentValidation;
using MediaLibrary.Application.Behaviors;
using MediaLibrary.Application.Implementations;
using MediaLibrary.Application.Interfaces;
using MediaLibrary.Application.Middleware;
using MediaLibrary.Domain.Settings;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using NuGet.Configuration;
using System.Configuration;
using System.Reflection;
using System.Text;

namespace MediaLibrary.Application;

public static class DependencyInjection
{
    public static void AddExceptionMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<CustomExceptionMiddleware>();
    }

    public static void AddServiceLayer(this IServiceCollection services)
    {
        // or you can use assembly in Extension method in Infra layer with below command
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

            cfg.AddOpenBehavior(typeof(ValidationMediatrBehavior<,>)); 
        });
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public static void AddJWTService(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddAuthentication(cfg => 
        {
            cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(o =>
        {
            o.RequireHttpsMetadata = false;
            o.Authority = configuration.GetSection("JWTSettings:Issuer").Value;
            o.SaveToken = false;
            o.IncludeErrorDetails = true;
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,

                ValidIssuer = configuration.GetSection("JWTSettings:Issuer").Value,
                ValidAudience = configuration.GetSection("JWTSettings:Audience").Value,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("JWTSettings:Key").Value))
            };
        });

        services.Configure<JWTSettings>(configuration.GetSection(nameof(JWTSettings)));

        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 5;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
        });
    }

    public static void AddEmailService(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MailSettings>(configuration.GetSection(nameof(MailSettings)));

        services.AddSingleton<IEmailService, EmailService>();
    }

}