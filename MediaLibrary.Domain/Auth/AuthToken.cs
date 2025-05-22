using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Domain.Auth;

public class AuthToken
{
    AuthToken(string message)
    {
        Message = message;
        IsAuthenticated = false;
    }
    AuthToken(string userName, string email, IEnumerable<string> roles, string token, string refreshToken)
    {
        Message = "";
        IsAuthenticated = true;
        UserName = userName;
        Email = email;
        Roles = roles.ToList();
        Token = token;
        RefreshToken = refreshToken;
    }

    public string Message { get; set; } = string.Empty;
    public bool IsAuthenticated { get; set; }

    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public List<string> Roles { get; set; } = [];
    public string Token { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;

    public static AuthToken Invalid(string message) => new (message);
    public static AuthToken Valid(string userName, string email, IEnumerable<string> roles, string token, string refreshToken) => 
        new (userName, email, roles, token, refreshToken);
}