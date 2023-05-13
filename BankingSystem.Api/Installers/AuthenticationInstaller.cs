using BankingSystem.Api.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace BankingSystem.Api.Installers;

public static class AuthenticationInstaller
{
    public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var options = configuration.GetSection("Authentication");
        services.Configure<AuthenticationOptions>(options);

        // Configure authentication (based on jwt tokens)
        var authOptions = options.Get<AuthenticationOptions>();
        if (authOptions is null)
            throw new ArgumentException("Can not find auth options section in appsettings.json");
        
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = authOptions.Issuer,

                    ValidateAudience = true,
                    ValidAudience = authOptions.Audience,

                    ValidateLifetime = true,

                    IssuerSigningKey = authOptions.GetSymmetricSecurityKey(),
                    ValidateIssuerSigningKey = true
                };
            });

        services.AddHttpContextAccessor();
    }
}