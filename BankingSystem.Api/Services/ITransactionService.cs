using BankingSystem.Api.Domain;
using FluentResults;

namespace BankingSystem.Api.Services;

public interface ITransactionService
{
    Task<Result> CreateAsync(WithdrawTransactionDomain transaction, CancellationToken cancellationToken);
    Task<Result> CreateAsync(ReplenishTransactionDomain transaction, CancellationToken cancellationToken);
}