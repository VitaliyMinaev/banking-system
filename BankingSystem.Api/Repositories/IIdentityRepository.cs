using FluentResults;

namespace BankingSystem.Api.Repositories;

public interface IIdentityRepository
{
    Task<Result> RegisterAsync(string username, string passwordHash, CancellationToken cancellationToken);
    Task<Result> LoginAsync(string username, string passwordHash, CancellationToken cancellationToken);
    Task<bool> UsernameAlreadyExistsAsync(string username, CancellationToken cancellationToken);
}