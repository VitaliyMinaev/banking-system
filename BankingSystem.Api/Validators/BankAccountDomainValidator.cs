using BankingSystem.Api.Domain;
using FluentValidation;

namespace BankingSystem.Api.Validators;

public class BankAccountDomainValidator : AbstractValidator<BankAccountDomain>
{
    public BankAccountDomainValidator()
    {
        RuleFor(x => x.Money)
            .GreaterThanOrEqualTo(0);
    }
}