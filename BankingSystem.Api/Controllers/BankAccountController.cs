using BankingSystem.Api.Extensions;
using BankingSystem.Api.Mappers;
using BankingSystem.Api.Services;
using BankingSystem.Common;
using BankingSystem.Common.Contracts.Requests;
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

    [HttpGet, Route(ApiRoutes.BankAccount.Get)]
    public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var bankAccount = await _bankAccountService.GetAsync(id, cancellationToken);
        if (bankAccount is null)
            return NotFound();

        return Ok(bankAccount.ToViewModel());
    }

    [HttpPut, Route(ApiRoutes.BankAccount.Withdraw)]
    public async Task<IActionResult> Withdraw([FromBody] WithdrawRequest request)
    {
        // get user id -> get from it bank account -> validate operation -> execute operation -> return result 
        (bool, Guid) tryResult = User.TryGetUserId();
        if (tryResult.Item1 == false)
            return Unauthorized();
        
        throw new NotImplementedException();
    }

    [HttpPut, Route(ApiRoutes.BankAccount.Replenish)]
    public async Task<IActionResult> Replenish([FromBody] ReplenishRequest request)
    {
        throw new NotImplementedException();
    }
}