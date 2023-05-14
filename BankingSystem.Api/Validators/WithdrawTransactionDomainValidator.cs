using BankingSystem.Api.Constants;
using BankingSystem.Api.Domain;
using BankingSystem.Api.Repositories;
using FluentValidation;

namespace BankingSystem.Api.Validators;

public class WithdrawTransactionDomainValidator : AbstractValidator<WithdrawTransactionDomain>
{
    public WithdrawTransactionDomainValidator(IIdentityRepository identityRepository)
    {
        RuleFor(x => x.OwnerOfBankAccountId)
            .NotEmpty()
            .MustAsync(async (userId, cancellationToken) =>
            {
                var user = await identityRepository.GetByIdAsync(userId, cancellationToken);
                return user is not null;
            })
            .WithMessage(ErrorMessages.BankAccount.Operations.RecipientNotFound);

        RuleFor(x => x.Amount)
            .GreaterThan(0);
    }
}