using FluentValidation;

namespace BankingSystem.Api.Installers;

public static class FluentValidationInstaller
{
    public static void ConfigureFluentValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(IAssemblyMarker).Assembly);
    }
}