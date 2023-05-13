using BankingSystem.Api.Domain;
using BankingSystem.Api.Entities;
using BankingSystem.Api.Mappers;
using BankingSystem.Api.Repositories;
using FluentResults;
using FluentValidation;
using FluentValidation.Results;

namespace BankingSystem.Api.Services;

public class IdentityService : IIdentityService
{
    private readonly IIdentityRepository _identityRepository;
    private readonly IBankAccountRepository _bankAccountRepository;
    private readonly IValidator<RegistrationFormDomain> _registrationFormValidator;
    private readonly IValidator<LoginFormDomain> _loginFormValidator;
    private readonly HashProvider _hashProvider;
    public IdentityService(IValidator<RegistrationFormDomain> registrationFormValidator, IIdentityRepository identityRepository, IValidator<LoginFormDomain> loginFormValidator, HashProvider hashProvider, IBankAccountRepository bankAccountRepository)
    {
        _registrationFormValidator = registrationFormValidator;
        _identityRepository = identityRepository;
        _loginFormValidator = loginFormValidator;
        _hashProvider = hashProvider;
        _bankAccountRepository = bankAccountRepository;
    }

    public async Task<IEnumerable<UserDomain>> GetAllAsync(CancellationToken cancellationToken)
    {
        var users = await _identityRepository.GetAllAsync(cancellationToken);
        return users.Select(x => x.ToDomain());
    }

    public async Task<Result<UserDomain>> CreateUserAsync(RegistrationFormDomain form, CancellationToken cancellationToken)
    {
        var validationResult = await _registrationFormValidator.ValidateAsync(form, cancellationToken);
        if (validationResult.IsValid == false)
        {
            return HandleValidationErrors(validationResult.Errors);
        }

        var bankAccountCreatingResult = await _bankAccountRepository.CreateAsync(new BankAccountEntity { Money = 0 }, cancellationToken);
        if (bankAccountCreatingResult.IsFailed)
            return Result.Fail(bankAccountCreatingResult.Errors);

        var bankAccount = bankAccountCreatingResult.Value;
        string passwordHash = _hashProvider.GenerateHash(form.Password);
        var registrationResult = await _identityRepository.CreateUserAsync(form.Username, passwordHash, bankAccount.Id, cancellationToken);
        return ToServiceResponse(registrationResult);
    }

    public async Task<Result<UserDomain>> LoginAsync(LoginFormDomain form, CancellationToken cancellationToken)
    {        
        var validationResult = await _loginFormValidator.ValidateAsync(form, cancellationToken);
        if (validationResult.IsValid == false)
        {
            return HandleValidationErrors(validationResult.Errors);
        }

        string passwordHash = _hashProvider.GenerateHash(form.Password);
        var loginResult = await _identityRepository.LoginAsync(form.Username, passwordHash, cancellationToken);
        return ToServiceResponse(loginResult);
    }

    private Result HandleValidationErrors(IEnumerable<ValidationFailure> validationFailures)
    {
        var errors = validationFailures .Select(x => new Error(x.ErrorMessage, 
            new Error(x.PropertyName)));
        return Result.Fail(errors);
    }

    private Result<UserDomain> ToServiceResponse(Result<ApplicationUserEntity> result)
    {
        if (result.IsFailed)
            return Result.Fail(result.Errors);
        return Result.Ok(result.Value.ToDomain());
    }
}