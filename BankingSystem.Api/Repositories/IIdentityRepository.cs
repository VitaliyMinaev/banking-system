using BankingSystem.Api.Entities;
using FluentResults;

namespace BankingSystem.Api.Repositories;

public interface IIdentityRepository
{
    Task<ApplicationUserEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken); 
    Task<IEnumerable<ApplicationUserEntity>> GetAllAsync(CancellationToken cancellationToken);
    Task<Result<ApplicationUserEntity>> CreateUserAsync(string username, string passwordHash, Guid bankAccountId, CancellationToken cancellationToken);
    Task<Result<ApplicationUserEntity>> LoginAsync(string username, string passwordHash, CancellationToken cancellationToken);
    Task<bool> UsernameAlreadyExistsAsync(string username, CancellationToken cancellationToken);
}