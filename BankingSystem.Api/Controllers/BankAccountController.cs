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

[Authorize]
public class BankAccountController : ControllerBase
{
    private readonly IBankAccountService _bankAccountService;
    public BankAccountController(IBankAccountService bankAccountService)
    {
        _bankAccountService = bankAccountService;
    }

    [HttpGet, Route(ApiRoutes.BankAccount.GetByUser)]
    public async Task<IActionResult> GetByUserId(CancellationToken cancellationToken)
    {
        (bool, Guid) tryResult = User.TryGetUserId();
        if (tryResult.Item1 == false)
            return Unauthorized();
        Guid userId = tryResult.Item2;
        
        var bankAccount = await _bankAccountService.GetByUserIdAsync(userId, cancellationToken);
        if (bankAccount is null)
            return NotFound();

        return Ok(bankAccount.ToViewModel());
    }
    [HttpGet, Route(ApiRoutes.BankAccount.GetById)]
    public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var bankAccount = await _bankAccountService.GetAsync(id, cancellationToken);
        if (bankAccount is null)
            return NotFound();

        return Ok(bankAccount.ToViewModel());
    }

    [HttpPut, Route(ApiRoutes.BankAccount.Withdraw)]
    public async Task<IActionResult> Withdraw([FromBody] WithdrawRequest request, CancellationToken cancellationToken)
    {
        (bool, Guid) tryResult = User.TryGetUserId();
        if (tryResult.Item1 == false)
            return Unauthorized();

        Guid userId = tryResult.Item2;
        var result = await _bankAccountService.WithdrawAsync(new WithdrawTransactionDomain(userId, request.Amount),
                cancellationToken);

        return HandleTransactionResult(result);
    }

    [HttpPut, Route(ApiRoutes.BankAccount.TopUp)]
    public async Task<IActionResult> TopUp([FromBody] TopUpRequest request, CancellationToken cancellationToken)
    {
        (bool, Guid) tryResult = User.TryGetUserId();
        if (tryResult.Item1 == false)
            return Unauthorized();

        Guid userId = tryResult.Item2;
        var result = await _bankAccountService.TopUpAsync(new TopUpTransactionDomain(userId, request.Amount),
            cancellationToken);

        return HandleTransactionResult(result);
    }
    
    [HttpPut, Route(ApiRoutes.BankAccount.Replenish)]
    public async Task<IActionResult> Replenish([FromBody] ReplenishRequest request, CancellationToken cancellationToken)
    {
        (bool, Guid) tryResult = User.TryGetUserId();
        if (tryResult.Item1 == false)
            return Unauthorized();

        Guid userId = tryResult.Item2;
        var result = await _bankAccountService.ReplenishAsync(new ReplenishTransactionDomain(userId, request.RecipientId, request.Amount),
            cancellationToken);

        return HandleTransactionResult(result);
    }
    
    private IActionResult HandleTransactionResult(Result<BankAccountDomain> result)
    {
        if (result.IsFailed)
        {
            if (result.IsValidationProblem() == true)
                return ValidationProblem(result.BuildModelState());

            var failedResponse = new TransactionFailedResponse() { Errors = result.Errors.Select(x => x.Message).ToArray() };
            return BadRequest(failedResponse);
        }

        return Ok(new TransactionSuccessResponse { BankAccountAmount = result.Value.Money });
    }
}