using BankingSystem.Api.Entities;
using FluentResults;

namespace BankingSystem.Api.Repositories;

public interface IIdentityRepository
{
    Task<IEnumerable<ApplicationUserEntity>> GetAllAsync(CancellationToken cancellationToken);
    Task<Result<ApplicationUserEntity>> RegisterAsync(string username, string passwordHash, CancellationToken cancellationToken);
    Task<Result<ApplicationUserEntity>> LoginAsync(string username, string passwordHash, CancellationToken cancellationToken);
    Task<bool> UsernameAlreadyExistsAsync(string username, CancellationToken cancellationToken);
}