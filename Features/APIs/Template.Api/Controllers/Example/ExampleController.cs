using Microsoft.AspNetCore.Mvc;
using Template.Api.Core.Services.Example.Contracts;

namespace Template.Api.Controllers.Example;

/// <summary>
/// Это только пример контроллера, который показывает вызов сервиса.
/// </summary>
[ApiController]
[Route("api/example")]
public sealed class ExampleController(
    IExampleService exampleService
) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(
        [FromQuery] string value = "example",
        CancellationToken ct = default
    )
    {
        var result = await exampleService.GetExampleAsync(value, ct);
        return Ok(result);
    }
}
