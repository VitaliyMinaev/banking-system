using BankingSystem.Api.Constants;
using BankingSystem.Api.Data;
using BankingSystem.Api.Entities;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.Api.Repositories;

public class BankAccountRepository : IBankAccountRepository
{
    private readonly ApplicationDatabaseContext _context;
    private readonly ILogger<BankAccountRepository> _logger;
    public BankAccountRepository(ApplicationDatabaseContext context, ILogger<BankAccountRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<BankAccountEntity?> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var bankAccount = await _context.BankAccounts.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        return bankAccount;
    }

    public async Task<Result<BankAccountEntity>> CreateAsync(BankAccountEntity bankAccount, CancellationToken cancellationToken)
    {
        ValidateFieldsIfInvalidThrowException(bankAccount);

        if (bankAccount.Id == Guid.Empty)
        {
            bankAccount.Id = Guid.NewGuid();
        }
        
        await _context.BankAccounts.AddAsync(bankAccount, cancellationToken);
        int updated = await _context.SaveChangesAsync(cancellationToken);
        return ToServiceResponse(bankAccount, updated);
    }

    public async Task<Result<BankAccountEntity>> UpdateAsync(BankAccountEntity designation, CancellationToken cancellationToken)
    {
        ValidateFieldsIfInvalidThrowException(designation);

        var source = await GetAsync(designation.Id, cancellationToken);
        if (source is null)
            return Result.Fail(new Error(ErrorMessages.BankAccount.NotFound));

        source.Money = designation.Money;
        int updated = await _context.SaveChangesAsync(cancellationToken);
        return ToServiceResponse(source, updated);
    }

    public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var bankAccount = await GetAsync(id, cancellationToken);
        if (bankAccount is null)
            return Result.Fail(new Error(ErrorMessages.BankAccount.NotFound));

        _context.BankAccounts.Remove(bankAccount);
        await _context.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }
    
    private Result<BankAccountEntity> ToServiceResponse(BankAccountEntity toReturn, int updated)
    {
        if (updated > 0 == false)
        {
            _logger.LogWarning(ErrorMessages.Database.Failed);
        }
        
        return Result.Ok(toReturn);
    }
    
    private void ValidateFieldsIfInvalidThrowException(BankAccountEntity bankAccount)
    {
        if (bankAccount.Money < 0)
            throw new ArgumentException("Money in bank account can not be less then 0");
    }
}