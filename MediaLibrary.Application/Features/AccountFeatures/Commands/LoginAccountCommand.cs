using MediaLibrary.Application.Features.AccountFeatures.Commands.Extensions;
using MediaLibrary.Application.Interfaces;
using MediaLibrary.Domain.Auth;
using MediaLibrary.Domain.Settings;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MediaLibrary.Application.Features.AccountFeatures.Commands;

public class LoginAccountCommand : IRequest<AuthToken>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    [JsonIgnore]
    public string IpAddress { get; set; } = string.Empty;
}

public class LoginAccountCommandHandler : IRequestHandler<LoginAccountCommand, AuthToken>
{

    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly JWTSettings _jwt;

    public LoginAccountCommandHandler(
        UserManager<ApplicationUser> userManager, 
        RoleManager<IdentityRole> roleManager, 
        IOptions<JWTSettings> jwt)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _jwt = jwt.Value;
    }

    public async Task<AuthToken> Handle(LoginAccountCommand request, CancellationToken cancellationToken)
    {
        return await GetTokenAsync(request);
    }

    public async Task<AuthToken> GetTokenAsync(LoginAccountCommand request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        
        if (user == null) 
            return AuthToken.Invalid($"No Accounts Registered with {request.Email}.");

        if (!IsPasswordCorrect(user, request.Password).Result) 
            return AuthToken.Invalid($"Incorrect Credentials for user {user.Email}.");
        
        string username = user.UserName ?? "";
        string email = user.Email ?? "";
        var rolesList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
        string jwtSecurityToken = new JwtSecurityTokenHandler().WriteToken(await _userManager.CreateJwt(_jwt, user));
        RefreshToken refreshToken = _userManager.CreateRefreshToken(request.IpAddress);

        AuthToken authToken = AuthToken.Valid(
            username,
            email,
            rolesList,
            jwtSecurityToken,
            refreshToken.Token
        );

        await _userManager.RevokeRefreshTokenWithNewTokenAsync(user, refreshToken, request.IpAddress);
        await _userManager.StoreNewRefreshTokenAsync(user, refreshToken);

        return authToken;
    }

    private async Task<bool> IsPasswordCorrect(ApplicationUser user, string password) => await _userManager.CheckPasswordAsync(user, password);
}