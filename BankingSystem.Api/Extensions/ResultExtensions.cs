using BankingSystem.Api.Constants;
using FluentResults;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BankingSystem.Api.Extensions;

public static class ResultExtensions
{
    public static bool IsValidationProblem(this Result result)
    {
        if (result.IsSuccess)
            throw new ArgumentException("Result can not be success for validating errors");
        
        var reasons = result.Errors.SelectMany(x => x.Reasons);
        return reasons.Any();
    }
    public static bool IsValidationProblem<T>(this Result<T> result)
    {
        if (result.IsSuccess)
            throw new ArgumentException("Result can not be success for validating errors");
        
        var reasons = result.Errors.SelectMany(x => x.Reasons);
        return reasons.Any();
    }
    
    public static ModelStateDictionary BuildModelState(this Result result)
    {
        if (result.IsSuccess)
            throw new ArgumentException("Result can not be success for validating errors");

        var modelStateDictionary = new ModelStateDictionary();
        foreach (var error in result.Errors)
        {
            var causedBy = error.Reasons.FirstOrDefault();
            if (causedBy is null)
                throw new NullReferenceException("We can not build model state dictionary without reasons of error");
            
            modelStateDictionary.AddModelError(causedBy.Message, error.Message);
        }

        return modelStateDictionary;
    }
    public static ModelStateDictionary BuildModelState<T>(this Result<T> result)
    {
        if (result.IsSuccess)
            throw new ArgumentException("Result can not be success for validating errors");

        var modelStateDictionary = new ModelStateDictionary();
        foreach (var error in result.Errors)
        {
            var causedBy = error.Reasons.FirstOrDefault();
            if (causedBy is null)
                throw new NullReferenceException("We can not build model state dictionary without reasons of error");
            
            modelStateDictionary.AddModelError(causedBy.Message, error.Message);
        }

        return modelStateDictionary;
    }
}