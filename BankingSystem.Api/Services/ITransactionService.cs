using BankingSystem.Api.Domain;
using FluentResults;

namespace BankingSystem.Api.Services;

public interface ITransactionService
{
    Task<Result> CreateAsync(WithdrawTransactionDomain transaction, BankAccountDomain from, CancellationToken cancellationToken);
    Task<Result> CreateAsync(ReplenishTransactionDomain transaction, BankAccountDomain from, BankAccountDomain to, CancellationToken cancellationToken);
    Task<Result> CreateAsync(TopUpTransactionDomain transaction, BankAccountDomain to, CancellationToken cancellationToken);

}