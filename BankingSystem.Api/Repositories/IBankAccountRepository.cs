using BankingSystem.Api.Entities;
using FluentResults;

namespace BankingSystem.Api.Repositories;

public interface IBankAccountRepository
{
    Task<BankAccountEntity> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken);
    Task<BankAccountEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<Result<BankAccountEntity>> CreateAsync(BankAccountEntity bankAccount, CancellationToken cancellationToken);
    Task<Result<BankAccountEntity>> UpdateAsync(BankAccountEntity designation, CancellationToken cancellationToken);
    Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken);
}