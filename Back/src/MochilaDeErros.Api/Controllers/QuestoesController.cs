using Microsoft.AspNetCore.Mvc;
using MochilaDeErros.Application.UseCases.Questoes;
using MochilaDeErros.Application.DTOs.Questoes;

[ApiController]
[Route("api/mochilas/{mochilaId}/questoes")]
public class QuestoesController : ControllerBase
{
    private readonly GetQuestoesCardsByMochilaIdUseCase _getCardsUseCase;
    private readonly CreateQuestaoUseCase _createQuestaoUseCase;

    public QuestoesController(
        GetQuestoesCardsByMochilaIdUseCase getCardsUseCase,
        CreateQuestaoUseCase createQuestaoUseCase)
    {
        _getCardsUseCase = getCardsUseCase;
        _createQuestaoUseCase = createQuestaoUseCase;
    }

    [HttpGet("cards")]
    public async Task<IActionResult> GetCards(
        Guid mochilaId,
        [FromQuery] Guid userId)
    {
        var result = await _getCardsUseCase.ExecuteAsync(userId, mochilaId);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        Guid mochilaId,
        [FromBody] CreateQuestaoRequest request)
    {
        request.MochilaId = mochilaId;

        var id = await _createQuestaoUseCase.ExecuteAsync(request);

        return StatusCode(StatusCodes.Status201Created, new { id });
    }
}

