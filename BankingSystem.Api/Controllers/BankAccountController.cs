using BankingSystem.Common;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.Api.Controllers;

public class BankAccountController : ControllerBase
{
    [HttpGet, Route(ApiRoutes.BankAccount.Get)]
    public async Task<IActionResult> Get()
    {
        throw new NotImplementedException();
    }
}