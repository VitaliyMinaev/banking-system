using BankingSystem.Api.Domain;
using FluentResults;

namespace BankingSystem.Api.Services;

public interface IBankAccountService
{
    Task<BankAccountDomain?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken);
    Task<BankAccountDomain?> GetAsync(Guid id, CancellationToken cancellationToken);
    Task<Result<Guid>> CreateAsync(BankAccountDomain bankAccount, CancellationToken cancellationToken);
    Task<Result<BankAccountDomain>> WithdrawAsync(WithdrawTransactionDomain transaction, CancellationToken cancellationToken);
    Task<Result<BankAccountDomain>> ReplenishAsync(ReplenishTransactionDomain transaction, CancellationToken cancellationToken);
    Task<Result<BankAccountDomain>> TopUpAsync(TopUpTransactionDomain transaction, CancellationToken cancellationToken);

}