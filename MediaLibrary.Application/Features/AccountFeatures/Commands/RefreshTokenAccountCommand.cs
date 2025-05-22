using MediaLibrary.Application.Exceptions.Accounts;
using MediaLibrary.Application.Features.AccountFeatures.Commands.Extensions;
using MediaLibrary.Application.Interfaces;
using MediaLibrary.Domain.Auth;
using MediaLibrary.Domain.Settings;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.FeatureManagement;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Asn1.Ocsp;
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

public class RefreshTokenAccountCommand : IRequest<AuthToken>
{
    public string Token { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;

    [JsonIgnore]
    public string IpAddress { get; set; } = string.Empty;
}

public class RefreshTokenAccountCommandHandler : IRequestHandler<RefreshTokenAccountCommand, AuthToken>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly JWTSettings _jwt;
    private readonly IEmailService _emailService;
    private readonly IFeatureManager _featureManager;

    public RefreshTokenAccountCommandHandler(
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

    public async Task<AuthToken> Handle(RefreshTokenAccountCommand request, CancellationToken cancellationToken)
    {
        string? username = GetUsernameFromClaim(request.Token);
        if (string.IsNullOrEmpty(username)) throw new AccountApiException("Invalid access token/refresh token");

        var user = await _userManager.Users.Include(x => x.RefreshTokens).FirstOrDefaultAsync(x => x.UserName == username);
        if (user == null) throw new AccountApiException("Invalid access token/refresh token");

        var refreshToken = user.FirstTokenOrDefault(request.RefreshToken);
        if (refreshToken == null) throw new AccountApiException("Invalid access token/refresh token");
        if (refreshToken.IsActive == false) throw new AccountApiException("Invalid access token/refresh token");

        string email = user.Email ?? "";
        var rolesList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
        string jwtSecurityToken = new JwtSecurityTokenHandler().WriteToken(await _userManager.CreateJwt(_jwt, user));
        RefreshToken newRefreshToken = _userManager.CreateRefreshToken(request.IpAddress);

        var authToken = AuthToken.Valid(
            username,
            email,
            rolesList,
            jwtSecurityToken,
            newRefreshToken.Token
        );

        await _userManager.RevokeRefreshTokenWithNewTokenAsync(user, newRefreshToken, request.IpAddress);
        await _userManager.StoreNewRefreshTokenAsync(user, newRefreshToken);
        return authToken;
    }
    
    private string? GetUsernameFromClaim(string token) => 
        GetPrincipalFromExpiredToken(token)?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

    private ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key)),
            ValidateLifetime = false
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);

        if (securityToken is not JwtSecurityToken jwtSecurityToken ||
                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            throw new SecurityTokenException("Invalid token");

        return principal;
    }
}
