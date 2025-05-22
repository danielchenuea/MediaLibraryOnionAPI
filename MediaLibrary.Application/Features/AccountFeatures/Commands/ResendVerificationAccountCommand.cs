using MediaLibrary.Application.Exceptions.Accounts;
using MediaLibrary.Application.Features.AccountFeatures.Commands.Extensions;
using MediaLibrary.Application.Interfaces;
using MediaLibrary.Domain.Auth;
using MediaLibrary.Domain.Enums;
using MediaLibrary.Domain.Settings;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.FeatureManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MediaLibrary.Application.Features.AccountFeatures.Commands;

public class ResendVerificationAccountCommand : IRequest
{
    public string Email { get; set; } = string.Empty;

    [JsonIgnore]
    public string Origin { get; set; } = string.Empty;
}


public class ResendVerificationAccountCommandHandler : IRequestHandler<ResendVerificationAccountCommand>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly JWTSettings _jwt;
    private readonly IEmailService _emailService;
    private readonly IFeatureManager _featureManager;

    public ResendVerificationAccountCommandHandler(
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

    public async Task Handle(ResendVerificationAccountCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null) throw new AccountApiException($"No Accounts Registered with {request.Email}");

        var isAlreadyConfirmed = await _userManager.IsEmailConfirmedAsync(user);

        if (isAlreadyConfirmed) return;
        if (string.IsNullOrEmpty(user.Email)) return;

        string verificationUrl = await _userManager.GenerateVerificationURL(user, request.Origin);
        if (await _featureManager.IsEnabledAsync(nameof(FeaturesControl.EmailFeature))) 
            await _emailService.SendEmail_VerificationURL(user.Email, verificationUrl);
    }
}


