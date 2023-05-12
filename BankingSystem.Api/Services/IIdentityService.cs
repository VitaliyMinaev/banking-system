using BankingSystem.Api.Domain;
using FluentResults;

namespace BankingSystem.Api.Services;

public interface IIdentityService
{
    Task<Result> RegisterAsync(RegistrationFormDomain form, CancellationToken cancellationToken);
    Task<Result> LoginAsync(LoginFormDomain form, CancellationToken cancellationToken);
}