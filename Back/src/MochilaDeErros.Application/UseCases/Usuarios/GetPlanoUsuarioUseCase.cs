using MochilaDeErros.Application.DTOs.Usuarios;
using MochilaDeErros.Application.Interfaces;
using MochilaDeErros.Domain.Enums;

namespace MochilaDeErros.Application.UseCases.Usuarios;

public class GetPlanoUsuarioUseCase
{
    private readonly IUsuarioReadRepository _usuarioRepository;

    public GetPlanoUsuarioUseCase(IUsuarioReadRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<UsoPlanoDto> ExecuteAsync(Guid usuarioId)
    {
        var usuario = await _usuarioRepository
            .ObterComMochilasAsync(usuarioId);

        if (usuario is null)
            throw new Exception("Usuário não encontrado.");

        var limite = usuario.Plano == PlanoTipo.Gratuito
            ? 5
            : int.MaxValue;

        var utilizadas = usuario.Mochilas.Count;

        return new UsoPlanoDto
        {
            Limite = limite,
            Utilizadas = utilizadas
        };
    }
}
