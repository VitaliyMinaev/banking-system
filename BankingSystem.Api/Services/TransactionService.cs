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

    public async Task<Result> CreateAsync(WithdrawTransactionDomain transaction, CancellationToken cancellationToken)
    {
        var entity = new TransactionEntity
        {
            Id = Guid.NewGuid(), 
            Amount = transaction.Amount, 
            BankAccountId = transaction.OwnerOfBankAccountId,
            BankAccountRecipientId = Guid.Empty
        };

        return await _transactionRepository.CreateAsync(entity, cancellationToken);
    }

    public async Task<Result> CreateAsync(ReplenishTransactionDomain transaction, CancellationToken cancellationToken)
    {
        var entity = new TransactionEntity
        {
            Id = Guid.NewGuid(), 
            Amount = transaction.Amount, 
            BankAccountId = transaction.SenderId,
            BankAccountRecipientId = transaction.RecipientId
        };

        return await _transactionRepository.CreateAsync(entity, cancellationToken);
    }
}