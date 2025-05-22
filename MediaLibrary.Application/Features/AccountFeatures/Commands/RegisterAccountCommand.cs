using MediaLibrary.Application.Exceptions.Accounts;
using MediaLibrary.Application.Features.AccountFeatures.Commands.Extensions;
using MediaLibrary.Application.Interfaces;
using MediaLibrary.Domain.Auth;
using MediaLibrary.Domain.Enums;
using MediaLibrary.Domain.Settings;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.FeatureManagement;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MediaLibrary.Application.Features.AccountFeatures.Commands;

public class RegisterAccountCommand : IRequest
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    [JsonIgnore]
    public string Origin { get; set; } = string.Empty;
}

public class RegisterAccountCommandHandler : IRequestHandler<RegisterAccountCommand>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly JWTSettings _jwt;
    private readonly IEmailService _emailService;
    private readonly IFeatureManager _featureManager;

    public RegisterAccountCommandHandler(
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IOptions<JWTSettings> jwt,
        IEmailService emailService,
        IFeatureManager featureManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _jwt = jwt.Value;
        _emailService = emailService;
        _featureManager = featureManager;
    }

    public async Task Handle(RegisterAccountCommand request, CancellationToken cancellationToken)
    {
        var user = new ApplicationUser()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            UserName = request.Username,
            Email = request.Email
        };

        var UserComEmail = await _userManager.FindByEmailAsync(user.Email);
        if (UserComEmail != null) throw new AccountApiException($"User with email '{user.Email}' already exists");

        var results = await _userManager.CreateAsync(user, request.Password);
        if (results.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, Roles.Basic.ToString());

            string verificationUrl = await _userManager.GenerateVerificationURL(user, request.Origin);
            if (await _featureManager.IsEnabledAsync(nameof(FeaturesControl.EmailFeature)))
                await _emailService.SendEmail_VerificationURL(user.Email, verificationUrl);
        }
        else
        {
            throw new RegistrationErrorException(results.Errors);
        }
    }
}
