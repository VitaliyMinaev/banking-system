using BankingSystem.Api.Domain;
using BankingSystem.Api.Entities;
using BankingSystem.Api.Repositories;
using FluentResults;

namespace BankingSystem.Api.Services;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;
    public TransactionService(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task<Result> CreateAsync(WithdrawTransactionDomain transaction, BankAccountDomain from, CancellationToken cancellationToken)
    {
        var entity = new TransactionEntity
        {
            Id = Guid.NewGuid(), 
            Amount = transaction.Amount, 
            BankAccountId = from.Id,
            BankAccountRecipientId = null
        };

        return await _transactionRepository.CreateAsync(entity, cancellationToken);
    }

    public async Task<Result> CreateAsync(ReplenishTransactionDomain transaction, BankAccountDomain from, BankAccountDomain to,
        CancellationToken cancellationToken)
    {
        var entity = new TransactionEntity
        {
            Id = Guid.NewGuid(), 
            Amount = transaction.Amount, 
            BankAccountId = from.Id,
            BankAccountRecipientId = to.Id
        };

        return await _transactionRepository.CreateAsync(entity, cancellationToken);
    }

    public async Task<Result> CreateAsync(TopUpTransactionDomain transaction, BankAccountDomain to, CancellationToken cancellationToken)
    {
        var entity = new TransactionEntity
        {
            Id = Guid.NewGuid(), 
            Amount = transaction.Amount, 
            BankAccountId = null,
            BankAccountRecipientId = to.Id
        };

        return await _transactionRepository.CreateAsync(entity, cancellationToken);
    }
}