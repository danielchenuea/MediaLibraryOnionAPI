using MediaLibrary.Application.Exceptions.Accounts;
using MediaLibrary.Application.Features.AccountFeatures.Commands.Extensions;
using MediaLibrary.Application.Implementations;
using MediaLibrary.Application.Interfaces;
using MediaLibrary.Domain.Auth;
using MediaLibrary.Domain.Enums;
using MediaLibrary.Domain.Mail;
using MediaLibrary.Domain.Settings;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.FeatureManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace MediaLibrary.Application.Features.AccountFeatures.Commands;

public class ResetPasswordAccountCommand : IRequest
{
    public string Email { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string ConfirmPassword { get; set; } = string.Empty;
}

public class ResetPasswordAccountCommandHandler : IRequestHandler<ResetPasswordAccountCommand>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly JWTSettings _jwt;
    private readonly IEmailService _emailService;
    private readonly IFeatureManager _featureManager;

    public ResetPasswordAccountCommandHandler(
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

    public async Task Handle(ResetPasswordAccountCommand request, CancellationToken cancellationToken)
    {
        var account = await _userManager.FindByEmailAsync(request.Email);
        if (account == null) throw new AccountApiException($"No Accounts Registered with {request.Email}");

        if (await _featureManager.IsEnabledAsync(nameof(FeaturesControl.EmailFeature)))
            await _emailService.SendEmail_PasswordReseted(request.Email);
    }
}