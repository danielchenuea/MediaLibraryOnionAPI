using Microsoft.AspNetCore.Identity;

namespace MediaLibrary.Domain.Auth;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public List<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

    public bool OwnsActiveToken()
    {
        return FirstActiveTokenOrDefault() != null;
    }
    public bool OwnsToken(string token)
    {
        return FirstTokenOrDefault(token) != null;
    }
    public RefreshToken? FirstTokenOrDefault(string token)
    {
        return this.RefreshTokens?.FirstOrDefault(x => x.Token == token);
    }
    public RefreshToken? FirstActiveTokenOrDefault()
    {
        return this.RefreshTokens?.FirstOrDefault(x => x.IsActive == true);
    }



}
