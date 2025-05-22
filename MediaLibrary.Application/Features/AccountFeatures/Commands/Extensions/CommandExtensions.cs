using MediaLibrary.Application.Implementations;
using MediaLibrary.Application.Interfaces;
using MediaLibrary.Domain.Auth;
using MediaLibrary.Domain.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Application.Features.AccountFeatures.Commands.Extensions;

public static class CommandExtensions
{
    internal static async Task<string> GenerateVerificationURL(this UserManager<ApplicationUser> userManager, ApplicationUser user, string origin)
    {
        var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
        var route = "api/account/confirmEmail/";
        var endpointUri = new Uri(string.Concat($"{origin}/", route));
        var verificationUri = QueryHelpers.AddQueryString(endpointUri.ToString(), "userId", user.Id);
        verificationUri = QueryHelpers.AddQueryString(verificationUri, "code", code);
        //Email Service Call Here
        return verificationUri;
    }


    internal static async Task RevokeAllRefreshTokensAsync(this UserManager<ApplicationUser> _userManager)
    {
        foreach (var user in _userManager.Users)
        {
            user.RefreshTokens = user.RefreshTokens.Select(x => {
                if (x.IsActive == false) return x;

                x.RevokedByIp = Dns.GetHostEntry(Dns.GetHostName()).AddressList.First().ToString();
                x.ReplacedByToken = "";
                x.Revoked = DateTime.UtcNow;
                return x;
            }).ToList();
            await _userManager.UpdateAsync(user);
        }
    }
    internal static async Task RevokeRefreshTokenAsync(this UserManager<ApplicationUser> _userManager, ApplicationUser user)
    {
        user.RefreshTokens = user.RefreshTokens.Select(x => {
            if (x.IsActive == false) return x;

            x.RevokedByIp = Dns.GetHostEntry(Dns.GetHostName()).AddressList.First().ToString();
            x.ReplacedByToken = "";
            x.Revoked = DateTime.UtcNow;
            return x;
        }).ToList();
        await _userManager.UpdateAsync(user);
    }

    internal static async Task RevokeRefreshTokenWithNewTokenAsync(this UserManager<ApplicationUser> _userManager, ApplicationUser user, RefreshToken newToken, string ipAddress)
    {
        user.RefreshTokens = user.RefreshTokens.Select(x => {
            if (x.IsActive == false) return x;

            x.RevokedByIp = ipAddress;
            x.ReplacedByToken = newToken.Token;
            x.Revoked = DateTime.UtcNow;
            return x;
        }).ToList();
        await _userManager.UpdateAsync(user);
    }

    internal static async Task StoreNewRefreshTokenAsync(this UserManager<ApplicationUser> _userManager, ApplicationUser user, RefreshToken refresh)
    {
        user.RefreshTokens.Add(refresh);
        await _userManager.UpdateAsync(user);
    }

    internal static async Task<JwtSecurityToken> CreateJwt(this UserManager<ApplicationUser> _userManager, JWTSettings _jwt, ApplicationUser user)
    {
        var userClaims = await _userManager.GetClaimsAsync(user);
        var roles = await _userManager.GetRolesAsync(user);

        var roleClaims = new List<Claim>();

        for (int i = 0; i < roles.Count; i++)
        {
            roleClaims.Add(new Claim("roles", roles[i]));
        }

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim("uid", user.Id)
        }
            .Union(userClaims)
            .Union(roleClaims);

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwt.Issuer,
            audience: _jwt.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
            signingCredentials: signingCredentials
        );

        return jwtSecurityToken;
    }

    internal static RefreshToken CreateRefreshToken(this UserManager<ApplicationUser> _userManager, string ipAddress)
    {
        return new RefreshToken
        {
            Token = RandomTokenString(),
            Expires = DateTime.UtcNow.AddDays(7),
            Created = DateTime.UtcNow,
            CreatedByIp = ipAddress
        };
    }

    internal static string RandomTokenString()
    {
        var bytes = RandomNumberGenerator.GetBytes(40);
        // convert random bytes to hex string
        return BitConverter.ToString(bytes).Replace("-", "");
    }



}
