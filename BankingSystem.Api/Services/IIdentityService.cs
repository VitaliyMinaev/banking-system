using BankingSystem.Api.Domain;
using FluentResults;

namespace BankingSystem.Api.Services;

public interface IIdentityService
{
    Task<IEnumerable<UserDomain>> GetAllAsync(CancellationToken cancellationToken);
    Task<Result<UserDomain>> RegisterAsync(RegistrationFormDomain form, CancellationToken cancellationToken);
    Task<Result<UserDomain>> LoginAsync(LoginFormDomain form, CancellationToken cancellationToken);
}