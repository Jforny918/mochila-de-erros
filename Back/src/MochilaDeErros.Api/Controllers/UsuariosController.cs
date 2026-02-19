using Microsoft.AspNetCore.Mvc;
using MochilaDeErros.Application.UseCases.Usuarios;
using MochilaDeErros.Application.DTOs.Usuarios;

[ApiController]
[Route("api/usuarios")]
public class UsuarioController : ControllerBase
{
    private readonly GetPlanoUsuarioUseCase _getPlanoUsuarioUseCase;
    private readonly CreateUsuarioUseCase _createUsuarioUseCase;

    public UsuarioController(
        GetPlanoUsuarioUseCase getPlanoUsuarioUseCase, 
        CreateUsuarioUseCase createUsuarioUseCase)
    {
        _getPlanoUsuarioUseCase = getPlanoUsuarioUseCase;
        _createUsuarioUseCase = createUsuarioUseCase;
    }

    [HttpGet("uso-plano")]
    public async Task<IActionResult> ObterUsoPlano(
    [FromQuery] Guid usuarioId
    )
    {

    var result = await _getPlanoUsuarioUseCase
        .ExecuteAsync(usuarioId);

    return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateUsuarioDto dto)
    {
        var id = await _createUsuarioUseCase.ExecuteAsync(dto);

        return CreatedAtAction(
            nameof(Create),
            new { id },
            new { id });
    }
}