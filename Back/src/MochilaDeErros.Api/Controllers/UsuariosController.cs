using Microsoft.AspNetCore.Mvc;
using MochilaDeErros.Application.UseCases.Usuarios;
using MochilaDeErros.Application.DTOs.Usuarios;

[ApiController]
[Route("api/usuarios")]
public class UsuarioController : ControllerBase
{
    private readonly GetPlanoUsuarioUseCase _getPlanoUsuarioUseCase;

    public UsuarioController(GetPlanoUsuarioUseCase getPlanoUsuarioUseCase)
    {
        _getPlanoUsuarioUseCase = getPlanoUsuarioUseCase;
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

}