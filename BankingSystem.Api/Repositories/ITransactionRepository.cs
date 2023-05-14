using BankingSystem.Api.Entities;
using FluentResults;

namespace BankingSystem.Api.Repositories;

public interface ITransactionRepository
{
    Task<Result> CreateAsync(TransactionEntity transaction, CancellationToken cancellationToken);
}
