using BankingSystem.Api.Domain;
using FluentResults;

namespace BankingSystem.Api.Services;

public interface IBankAccountService
{
    Task<BankAccountDomain?> GetAsync(Guid id, CancellationToken cancellationToken);
    Task<Result<Guid>> CreateAsync(BankAccountDomain bankAccount, CancellationToken cancellationToken);
    Task<Result<Guid>> UpdateAsync(BankAccountDomain designation, CancellationToken cancellationToken);
}