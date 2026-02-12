using Microsoft.AspNetCore.Mvc;
using MochilaDeErros.Application.DTOs.Questoes;
using MochilaDeErros.Application.UseCases.Questoes;

namespace MochilaDeErros.Api.Controllers;

[ApiController]
[Route("api/mochilas/{mochilaId:guid}/questoes")]
public class QuestoesController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(
        Guid mochilaId,
        [FromBody] CreateQuestaoRequest request,
        [FromServices] CreateQuestaoUseCase useCase)
    {
        var id = await useCase.ExecuteAsync(mochilaId, request);
        return Ok(id);
    }

    [HttpGet]
    public async Task<IActionResult> GetQuestoesDaMochila(
        Guid mochilaId,
        [FromServices] GetQuestoesByMochilaUseCase useCase)
    {
        var result = await useCase.ExecuteAsync(mochilaId);
        return Ok(result);
    }

    [HttpGet("/api/mochilas/{mochilaId:guid}/questoes/proxima")]
    public async Task<IActionResult> GetProximaQuestao(
        Guid mochilaId,
        [FromServices] GetProximaQuestaoUseCase useCase)
    {
        var result = await useCase.ExecuteAsync(mochilaId);
        if (result is null) return NoContent();

        return Ok(result);
    }
}
