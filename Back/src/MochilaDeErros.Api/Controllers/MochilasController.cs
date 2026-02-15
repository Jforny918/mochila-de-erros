using Microsoft.AspNetCore.Mvc;
using MochilaDeErros.Application.UseCases.Mochilas;
using MochilaDeErros.Application.DTOs.Mochilas;

namespace MochilaDeErros.Api.Controllers;

[ApiController]
[Route("api/mochilas")]
public class MochilasController : ControllerBase
{
    [HttpGet("cards")]
    public async Task<IActionResult> GetCards(
        [FromQuery] Guid userId,
        [FromServices] GetMochilaCardsByUserIdUseCase useCase)
    {
        var result = await useCase.ExecuteAsync(userId);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateMochilaRequest request,
        [FromServices] CreateMochilaUseCase useCase)
    {
        var id = await useCase.ExecuteAsync(request);
        return CreatedAtAction(nameof(Create), new { id }, null);
    }
}
