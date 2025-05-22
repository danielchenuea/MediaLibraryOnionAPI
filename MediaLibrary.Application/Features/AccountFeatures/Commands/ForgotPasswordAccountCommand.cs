using MediaLibrary.Application.Implementations;
using MediaLibrary.Application.Interfaces;
using MediaLibrary.Domain.Auth;
using MediaLibrary.Domain.Mail;
using MediaLibrary.Domain.Settings;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MediaLibrary.Application.Features.AccountFeatures.Commands;

public class ForgotPasswordAccountCommand : IRequest
{
    public string Email { get; set; } = string.Empty;
    [JsonIgnore]
    public string Origin { get; set; } = string.Empty;
}

public class ForgotPasswordAccountCommandHandler : IRequestHandler<ForgotPasswordAccountCommand>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly JWTSettings _jwt;
    private readonly IEmailService _emailService;

    public ForgotPasswordAccountCommandHandler(
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IOptions<JWTSettings> jwt,
        IEmailService emailService)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _jwt = jwt.Value;
        _emailService = emailService;
    }

    public async Task Handle(ForgotPasswordAccountCommand request, CancellationToken cancellationToken)
    {
        var account = await _userManager.FindByEmailAsync(request.Email);

        // always return ok response to prevent email enumeration
        if (account == null) return;

        var code = await _userManager.GeneratePasswordResetTokenAsync(account);
        var emailRequest = new MailRequest()
        {
            Body = $"You reset token is - {code}",
            ToEmail = request.Email,
            Subject = "Reset Password",
        };
        await _emailService.SendEmailAsync(emailRequest);
    }
}
