using BankingSystem.Api.Services;

namespace BankingSystem.Api.Installers;

public static class ServicesInstaller
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IIdentityService, IdentityService>();
        services.AddScoped<JwtGeneratorService>();
    }
}