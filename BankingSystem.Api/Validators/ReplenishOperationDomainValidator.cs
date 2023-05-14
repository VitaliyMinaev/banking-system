using BankingSystem.Api.Constants;
using BankingSystem.Api.Domain;
using BankingSystem.Api.Repositories;
using FluentValidation;

namespace BankingSystem.Api.Validators;

public class ReplenishOperationDomainValidator : AbstractValidator<ReplenishTransactionDomain>
{
    public ReplenishOperationDomainValidator(IIdentityRepository identityRepository)
    {
        RuleFor(x => x.SenderId)
            .NotEmpty()
            .MustAsync(UserExistsAsync(identityRepository))
            .WithMessage(ErrorMessages.BankAccount.Operations.SenderNotFound);

        RuleFor(x => x.RecipientId)
            .NotEmpty()
            .MustAsync(UserExistsAsync(identityRepository))
            .WithMessage(ErrorMessages.BankAccount.Operations.RecipientNotFound);

        RuleFor(x => x.Amount)
            .GreaterThan(0);
    }

    private static Func<Guid, CancellationToken, Task<bool>> UserExistsAsync(IIdentityRepository identityRepository)
    {
        return async (id, cancellationToken) =>
        {
            var user = await identityRepository.GetByIdAsync(id, cancellationToken);
            return user is not null;
        };
    }
}