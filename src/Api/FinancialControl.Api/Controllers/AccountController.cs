using FinancialControl.Application.Interfaces.UseCases;
using FinancialControl.Application.UseCases.Account.Requests;
using Microsoft.AspNetCore.Mvc;

namespace FinancialControl.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    [HttpGet("Statement")]
    public async Task<IActionResult> GetStatement(
        [FromServices] IGetStatementUseCase useCase,
        [FromQuery] StatementRequest request)
    {
        var response = await useCase.GetStatement(request);
        return Ok(response);
    }
}
