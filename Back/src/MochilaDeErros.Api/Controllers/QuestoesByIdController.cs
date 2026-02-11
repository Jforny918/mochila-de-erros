using Microsoft.AspNetCore.Mvc;
using MochilaDeErros.Application.UseCases.Questoes;
using MochilaDeErros.Application.DTOs.Questoes;

namespace MochilaDeErros.Api.Controllers;

[ApiController]
[Route("api/questoes")]
public class QuestoesByIdController : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetQuestaoById(
        Guid id,
        [FromServices] GetQuestaoByIdUseCase useCase)
    {
        var result = await useCase.ExecuteAsync(id);
        if (result is null) return NotFound();
        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        [FromBody] UpdateQuestaoRequest request,
        [FromServices] UpdateQuestaoUseCase useCase)
    {
        await useCase.ExecuteAsync(id, request);
        return NoContent();
    }

    [HttpPost("/api/questoes/{id:guid}/responder")]
    public async Task<IActionResult> Responder(
        Guid id,
        [FromBody] ResponderQuestaoRequest request,
        [FromServices] ResponderQuestaoUseCase useCase)
    {
        var result = await useCase.ExecuteAsync(id, request.LetraMarcada);
        if (result is null) return NotFound();

        return Ok(result);
    }


}
