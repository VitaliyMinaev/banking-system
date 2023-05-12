using BankingSystem.Api.Constants;
using BankingSystem.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Api.Installers;

public static class DatabaseInstaller
{
    public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(ConnectionKeys.MssqlConnection);

        if (String.IsNullOrEmpty(connectionString))
        {
            throw new ArgumentException("Connection string not found!");
        }

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
    }
}