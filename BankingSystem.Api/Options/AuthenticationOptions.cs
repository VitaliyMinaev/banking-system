using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace BankingSystem.Api.Options;

public class AuthenticationOptions
{
    public string Issuer { get; set; } = String.Empty;
    public string Audience { get; set; } = String.Empty;
    public string Secret { get; set; } = String.Empty;
    public int TokenLifetime { get; set; } // secs

    public SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));
    }
}