using System.Text.RegularExpressions;
using BankingSystem.Api.Domain;
using BankingSystem.Api.Repositories;
using FluentValidation;

namespace BankingSystem.Api.Validators;

public class RegistrationFormDomainValidator : AbstractValidator<RegistrationFormDomain>
{
    public RegistrationFormDomainValidator(IIdentityRepository identityRepository)
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .MinimumLength(6)
            .MustAsync(async (username, cancellationToken) =>
            {
                var exists = await identityRepository.UsernameAlreadyExistsAsync(username, cancellationToken);
                if (exists)
                    return false;
                return true;
            })
            .WithMessage("User with given username already exists!");

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(6)
            .Must((password) =>
            {
                // Define the regular expression pattern for password validation
                string pattern = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
        
                // Create a Regex object with the pattern
                var regex = new Regex(pattern);
                // Use the Regex.IsMatch method to check if the password matches the pattern
                bool isValid = regex.IsMatch(password);
                return isValid;
            })
            .WithMessage("Password pattern is not correct");
    }
}