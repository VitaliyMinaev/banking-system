using BankingSystem.Api.Domain;
using BankingSystem.Api.Extensions;
using BankingSystem.Api.Mappers;
using BankingSystem.Api.Services;
using BankingSystem.Common;
using BankingSystem.Common.Contracts.Requests;
using BankingSystem.Common.Contracts.Responses;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.Api.Controllers;

public class IdentityController : ControllerBase
{
    private readonly IIdentityService _identityService;
    private readonly JwtGeneratorService _jwtGenerator;
    public IdentityController(IIdentityService identityService, JwtGeneratorService jwtGenerator)
    {
        _identityService = identityService;
        _jwtGenerator = jwtGenerator;
    }

    [HttpGet, Route(ApiRoutes.Identity.GetAll), Authorize]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var users = await _identityService.GetAllAsync(cancellationToken);
        return Ok(users.Select(x => x.ToViewModel()));
    }

    [HttpPost, Route(ApiRoutes.Identity.Register)]
    public async Task<IActionResult> Register([FromBody] RegistrationRequest request, CancellationToken cancellationToken)
    {
        if (ModelState.IsValid == false)
            return ValidationProblem(ModelState);
        
        var form = new RegistrationFormDomain(request.Username, request.Password);
        var result = await _identityService.CreateUserAsync(form, cancellationToken);
        return HandleAuthResult(result);
    }
    
    [HttpPost, Route(ApiRoutes.Identity.Login)]
    public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
    {
        if (ModelState.IsValid == false)
            return ValidationProblem(ModelState);
        
        var form = new LoginFormDomain(request.Username, request.Password);
        var result = await _identityService.LoginAsync(form, cancellationToken);
        
        return HandleAuthResult(result);
    }

    private IActionResult HandleAuthResult(Result<UserDomain> result)
    {
        if (result.IsFailed)
        {
            if (result.IsValidationProblem() == true)
                return ValidationProblem(result.BuildModelState());

            var failedResponse = new AuthenticationFailedResponse { ErrorMessages = result.Errors.Select(x => x.Message).ToArray() };
            return BadRequest(failedResponse);
        }

        var user = result.Value;
        var token = _jwtGenerator.GenerateGwt(user);
        return Ok(new AuthenticationSuccessResponse { AccessToken = token });
    }
}