using BankingSystem.Api.Domain;
using BankingSystem.Api.Mappers;
using BankingSystem.Api.Repositories;
using FluentResults;

namespace BankingSystem.Api.Services;

public class BankAccountService : IBankAccountService
{
    private readonly IBankAccountRepository _bankAccountRepository;
    public BankAccountService(IBankAccountRepository bankAccountRepository)
    {
        _bankAccountRepository = bankAccountRepository;
    }

    public async Task<BankAccountDomain?> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _bankAccountRepository.GetAsync(id, cancellationToken);
        if (entity is null)
            return null;

        return entity.ToDomain();
    }

    public Task<Result<Guid>> CreateAsync(BankAccountDomain bankAccount, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Result<Guid>> UpdateAsync(BankAccountDomain designation, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}