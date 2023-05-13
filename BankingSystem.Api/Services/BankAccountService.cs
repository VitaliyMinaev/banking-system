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
    private readonly IValidator<BankAccountDomain> _validator;
    public BankAccountService(IBankAccountRepository bankAccountRepository, IValidator<BankAccountDomain> validator)
    {
        _bankAccountRepository = bankAccountRepository;
        _validator = validator;
    }

    public async Task<BankAccountDomain?> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _bankAccountRepository.GetAsync(id, cancellationToken);
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
}