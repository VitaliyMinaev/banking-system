using BankingSystem.Api.Repositories;

namespace BankingSystem.Api.Installers;

public static class RepositoriesInstaller
{
    public static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IIdentityRepository, IdentityRepository>();
        services.AddScoped<IBankAccountRepository, BankAccountRepository>();
    }
}