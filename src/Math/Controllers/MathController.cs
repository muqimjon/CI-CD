using Math.Services;
using Microsoft.AspNetCore.Mvc;

namespace Math.API.Controllers;

[Route("[controller]")] 
[ApiController]
public class MathController : ControllerBase
{
    [HttpGet("add")]
    public async Task<IActionResult> AddAsync(
        [FromQuery] long a,
        [FromQuery] long b,
        [FromServices] IMathService mathService,
        CancellationToken cancellationToken = default)
        => Ok(new { result = await mathService.AddAsync(a, b, cancellationToken) });
}