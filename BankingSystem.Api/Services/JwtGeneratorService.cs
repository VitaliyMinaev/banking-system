using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BankingSystem.Api.Domain;
using BankingSystem.Api.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BankingSystem.Api.Services;

public class JwtGeneratorService
{
    private readonly IOptions<AuthenticationOptions> _options;

    public JwtGeneratorService(IOptions<AuthenticationOptions> options)
    {
        _options = options;
    }

    public string GenerateGwt(UserDomain user)
    {
        AuthenticationOptions authParams = _options.Value;

        SymmetricSecurityKey securityKey = authParams.GetSymmetricSecurityKey();
        var cridentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.GivenName, user.Username),
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
        };

        claims.Add(new Claim("role", "user"));

        var token = new JwtSecurityToken(authParams.Issuer,
            authParams.Audience,
            claims,
            expires: DateTime.Now.AddHours(24),
            signingCredentials: cridentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}