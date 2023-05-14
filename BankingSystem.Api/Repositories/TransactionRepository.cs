using BankingSystem.Api.Data;
using BankingSystem.Api.Domain;
using BankingSystem.Api.Entities;
using FluentResults;

namespace BankingSystem.Api.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly ApplicationDatabaseContext _context;
    public TransactionRepository(ApplicationDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Result> CreateAsync(TransactionEntity transaction, CancellationToken cancellationToken)
    {
        if (transaction is null)
            throw new ArgumentNullException();

        if (transaction.Id == Guid.Empty)
            transaction.Id = Guid.NewGuid();
        
        await _context.Transactions.AddAsync(transaction, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }
}