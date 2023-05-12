using BankingSystem.Api.Domain;
using FluentValidation;

namespace BankingSystem.Api.Validators;

public class LoginFormDomainValidator : AbstractValidator<LoginFormDomain>
{
    public LoginFormDomainValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .MinimumLength(6);

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(6);
    }
}