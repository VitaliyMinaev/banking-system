using BankingSystem.Common;
using BankingSystem.Common.Contracts.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.Api.Controllers;

public class HealthCheckController : ControllerBase
{
    [HttpGet, Route(ApiRoutes.HealthCheck.Check)]
    public IActionResult HealthCheck()
    {
        return Ok(new HealthCheckResponse { Status = "Service is online!"});
    }
}