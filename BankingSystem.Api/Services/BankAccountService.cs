using BankingSystem.Api.Constants;
using BankingSystem.Api.Domain;
using BankingSystem.Api.Extensions;
using BankingSystem.Api.Mappers;
using BankingSystem.Api.Repositories;
using FluentResults;
using FluentValidation;

namespace BankingSystem.Api.Services;

public class BankAccountService : IBankAccountService
{
    private readonly IBankAccountRepository _bankAccountRepository;
    private readonly ITransactionService _transactionService;
    private readonly IValidator<BankAccountDomain> _validator;
    private readonly IValidator<WithdrawTransactionDomain> _withdrawValidator;
    private readonly IValidator<ReplenishTransactionDomain> _replenishValidator;
    private readonly IValidator<TopUpTransactionDomain> _topUpValidator;
    private readonly ILogger<BankAccountService> _logger;
    public BankAccountService(IBankAccountRepository bankAccountRepository, IValidator<BankAccountDomain> validator, IValidator<WithdrawTransactionDomain> withdrawValidator, IValidator<ReplenishTransactionDomain> replenishValidator, ITransactionService transactionService, IValidator<TopUpTransactionDomain> topUpValidator, ILogger<BankAccountService> logger)
    {
        _bankAccountRepository = bankAccountRepository;
        _validator = validator;
        _withdrawValidator = withdrawValidator;
        _replenishValidator = replenishValidator;
        _transactionService = transactionService;
        _topUpValidator = topUpValidator;
        _logger = logger;
    }

    public async Task<BankAccountDomain?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _bankAccountRepository.GetByUserIdAsync(userId, cancellationToken);
            return entity.ToDomain();
        }
        catch (InvalidOperationException e)
        {
            return null;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Can not get bank account by user id!");
            throw;
        }
    }
    
    public async Task<BankAccountDomain?> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _bankAccountRepository.GetByIdAsync(id, cancellationToken);
        if (entity is null)
            return null;

        return entity.ToDomain();
    }

    public async Task<Result<Guid>> CreateAsync(BankAccountDomain bankAccount, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(bankAccount, cancellationToken);
        if (validationResult.IsValid == false)
        {
            return validationResult.ToFailedResult();
        }
        
        var creationResult = await _bankAccountRepository.CreateAsync(bankAccount.ToEntity(), cancellationToken);
        if (creationResult.IsSuccess)
            return Result.Ok(creationResult.Value.Id);
        return Result.Fail(creationResult.Errors);
    }

    public async Task<Result<BankAccountDomain>> WithdrawAsync(WithdrawTransactionDomain transaction, CancellationToken cancellationToken)
    {
        var validationResult = await _withdrawValidator.ValidateAsync(transaction, cancellationToken);
        if (validationResult.IsValid == false)
        {
            return validationResult.ToFailedResult();
        }
        
        var bankAccount = await _bankAccountRepository.GetByUserIdAsync(transaction.OwnerOfBankAccountId, cancellationToken);
        if (bankAccount.Money - transaction.Amount < 0)
            return Result.Fail(new Error(ErrorMessages.BankAccount.Operations.NotEnoughMoney));
        
        bankAccount.Money -= transaction.Amount;
        var transactionResult = await _bankAccountRepository.UpdateAsync(bankAccount, cancellationToken);
        
        if(transactionResult.IsFailed)
            return Result.Fail(transactionResult.Errors);

        var transactionAdding = await _transactionService.CreateAsync(transaction, bankAccount.ToDomain(), cancellationToken);
        if (transactionAdding.IsFailed)
        {
            throw new Exception($"Can not create transaction: {transactionAdding.Errors.First().Message}");
        }
        
        return Result.Ok(transactionResult.Value.ToDomain());
    }

    public async Task<Result<BankAccountDomain>> ReplenishAsync(ReplenishTransactionDomain transaction, CancellationToken cancellationToken)
    {
        var validationResult = await _replenishValidator.ValidateAsync(transaction, cancellationToken);
        if (validationResult.IsValid == false)
        {
            return validationResult.ToFailedResult();
        }
        
        var senderBankAccount = await _bankAccountRepository.GetByUserIdAsync(transaction.SenderId, cancellationToken);
        if (senderBankAccount.Money - transaction.Amount < 0)
            return Result.Fail(new Error(ErrorMessages.BankAccount.Operations.NotEnoughMoney));

        senderBankAccount.Money -= transaction.Amount;
        var transactionResult = await _bankAccountRepository.UpdateAsync(senderBankAccount, cancellationToken);
        if(transactionResult.IsFailed)
            return Result.Fail(transactionResult.Errors);
        
        var recipientBankAccount = await _bankAccountRepository.GetByUserIdAsync(transaction.RecipientId, cancellationToken);
        recipientBankAccount.Money += transaction.Amount;
        var recipientTransactionResult = await _bankAccountRepository.UpdateAsync(senderBankAccount, cancellationToken);
        if(recipientTransactionResult.IsFailed)
            return Result.Fail(transactionResult.Errors);

        var transactionAdding = await _transactionService.CreateAsync(transaction, 
            senderBankAccount.ToDomain(), recipientBankAccount.ToDomain(), cancellationToken);
        if (transactionAdding.IsFailed)
        {
            throw new Exception($"Can not create transaction: {transactionAdding.Errors.First().Message}");
        }
        
        return Result.Ok(transactionResult.Value.ToDomain());
    }

    public async Task<Result<BankAccountDomain>> TopUpAsync(TopUpTransactionDomain transaction, CancellationToken cancellationToken)
    {
        var validationResult = await _topUpValidator.ValidateAsync(transaction, cancellationToken);
        if (validationResult.IsValid == false)
        {
            return validationResult.ToFailedResult();
        }
        
        var bankAccount = await _bankAccountRepository.GetByUserIdAsync(transaction.UserId, cancellationToken);
        
        bankAccount.Money += transaction.Amount;
        var transactionResult = await _bankAccountRepository.UpdateAsync(bankAccount, cancellationToken);
        if(transactionResult.IsFailed)
            return Result.Fail(transactionResult.Errors);

        var transactionAdding = await _transactionService.CreateAsync(transaction, bankAccount.ToDomain(), cancellationToken);
        if (transactionAdding.IsFailed)
        {
            throw new Exception($"Can not create transaction: {transactionAdding.Errors.First().Message}");
        }
        
        return Result.Ok(transactionResult.Value.ToDomain());
    }
}