using BankingSystem.Api.Mappers;
using BankingSystem.Api.Services;
using BankingSystem.Common;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.Api.Controllers;

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
}