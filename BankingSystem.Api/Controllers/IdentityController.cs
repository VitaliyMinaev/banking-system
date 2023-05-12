using BankingSystem.Api.Domain;
using BankingSystem.Api.Extensions;
using BankingSystem.Api.Services;
using BankingSystem.Common;
using BankingSystem.Common.Contracts.Requests;
using BankingSystem.Common.Contracts.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.Api.Controllers;

public class IdentityController : ControllerBase
{
    private readonly IIdentityService _identityService;
    public IdentityController(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    [HttpPost, Route(ApiRoutes.Identity.Register)]
    public async Task<IActionResult> Register([FromBody] RegistrationRequest request, CancellationToken cancellationToken)
    {
        var form = new RegistrationFormDomain(request.Username, request.Password);
        var result = await _identityService.RegisterAsync(form, cancellationToken);
        
        if (result.IsFailed)
        {
            if (result.IsValidationProblem() == true)
                return ValidationProblem(result.BuildModelState());

            var failedResponse = new AuthenticationFailedResponse { ErrorMessages = result.Errors.Select(x => x.Message).ToArray() };
            return BadRequest(failedResponse);
        }

        // return access token
        throw new NotImplementedException();
    }
    
    [HttpPost, Route(ApiRoutes.Identity.Login)]
    public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
    {
        var form = new LoginFormDomain(request.Username, request.Password);
        var result = await _identityService.LoginAsync(form, cancellationToken);
        
        // validate result
        
        // return response

        throw new NotImplementedException();
    }
}