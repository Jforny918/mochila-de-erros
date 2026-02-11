using Microsoft.AspNetCore.Mvc;
using MochilaDeErros.Application.DTOs.Mochilas;
using MochilaDeErros.Application.UseCases.Mochilas;

namespace MochilaDeErros.Api.Controllers;

[ApiController]
[Route("api/mochilas")]
public class MochilasController : ControllerBase
{
    private readonly CreateMochilaUseCase _createUseCase;

    public MochilasController(CreateMochilaUseCase createUseCase)
    {
        _createUseCase = createUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateMochilaRequest request)
    {
        var id = await _createUseCase.ExecuteAsync(request);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromQuery] Guid userId,
        [FromServices] GetMochilasUseCase useCase)
    {
        var result = await useCase.ExecuteAsync(userId);
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(
        Guid id,
        [FromServices] GetMochilaByIdUseCase useCase)
    {
        var result = await useCase.ExecuteAsync(id);
        if (result is null) return NotFound();
        return Ok(result);
    }
}
