using FluentResults;
using FluentValidation.Results;

namespace BankingSystem.Api.Extensions;

public static class ValidationResultExtensions
{
    public static Result ToFailedResult(this ValidationResult validationResult)
    {
        var errors = validationResult.Errors.Select(x => new Error(x.ErrorMessage, 
            new Error(x.PropertyName)));
        return Result.Fail(errors);
    }
}