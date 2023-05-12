using BankingSystem.Api.Domain;
using BankingSystem.Api.Repositories;
using FluentResults;
using FluentValidation;
using FluentValidation.Results;

namespace BankingSystem.Api.Services;

public class IdentityService : IIdentityService
{
    private readonly IIdentityRepository _identityRepository;
    private readonly IValidator<RegistrationFormDomain> _registrationFormValidator;
    private readonly IValidator<LoginFormDomain> _loginFormValidator;
    public IdentityService(IValidator<RegistrationFormDomain> registrationFormValidator, IIdentityRepository identityRepository, IValidator<LoginFormDomain> loginFormValidator)
    {
        _registrationFormValidator = registrationFormValidator;
        _identityRepository = identityRepository;
        _loginFormValidator = loginFormValidator;
    }

    public async Task<Result> RegisterAsync(RegistrationFormDomain form, CancellationToken cancellationToken)
    {
        var validationResult = await _registrationFormValidator.ValidateAsync(form, cancellationToken);
        if (validationResult.IsValid == false)
        {
            HandleValidationErrors(validationResult.Errors);
        }

        var registrationResult = await _identityRepository.RegisterAsync(form.Username, form.Password, cancellationToken);
        return registrationResult;
    }

    public async Task<Result> LoginAsync(LoginFormDomain form, CancellationToken cancellationToken)
    {        
        var validationResult = await _loginFormValidator.ValidateAsync(form, cancellationToken);
        if (validationResult.IsValid == false)
        {
            HandleValidationErrors(validationResult.Errors);
        }

        var loginResult = await _identityRepository.LoginAsync(form.Username, form.Password, cancellationToken);
        return loginResult;
    }

    private Result HandleValidationErrors(IEnumerable<ValidationFailure> validationFailures)
    {
        var errors = validationFailures .Select(x => new Error(x.ErrorMessage, 
            new Error(x.PropertyName)));
        return Result.Fail(errors);
    }
}