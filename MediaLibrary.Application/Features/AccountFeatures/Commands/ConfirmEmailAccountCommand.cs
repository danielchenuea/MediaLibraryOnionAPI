using MediaLibrary.Application.Exceptions.Accounts;
using MediaLibrary.Application.Interfaces;
using MediaLibrary.Domain.Auth;
using MediaLibrary.Domain.Enums;
using MediaLibrary.Domain.Settings;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using Microsoft.FeatureManagement;
using System.Text;

namespace MediaLibrary.Application.Features.AccountFeatures.Commands;

public class ConfirmEmailAccountCommand : IRequest
{
    [FromQuery]
    public string UserId { get; set; } = string.Empty;
    [FromQuery]
    public string Code { get; set; } = string.Empty;
}

public class ConfirmEmailAccountCommandHandler : IRequestHandler<ConfirmEmailAccountCommand>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly JWTSettings _jwt;
    private readonly IEmailService _emailService;
    private readonly IFeatureManager _featureManager;

    public ConfirmEmailAccountCommandHandler(
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

    public async Task Handle(ConfirmEmailAccountCommand request, CancellationToken cancellationToken)
    {
        var account = await _userManager.FindByIdAsync(request.UserId);
        if (account == null) throw new AccountApiException($"No Accounts Found with {request.Code}");
       
        var codeDecoded = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(request.Code));
        var result = await _userManager.ConfirmEmailAsync(account, codeDecoded);
        
        if (result.Succeeded == false) throw new AccountApiException($"An error occured while confirming {account.Email}.");
    }
}

