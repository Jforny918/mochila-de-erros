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

        int limite = usuario.Plano switch
    {
        PlanoTipo.Gratuito => 5,
        PlanoTipo.Premium => 20,
        PlanoTipo.Empresarial => -1,
        _ => 5
    };

    int utilizadas = usuario.Mochilas.Count;

    double percentual = limite == -1
        ? 0
        : (double)utilizadas / limite * 100;

    return new UsoPlanoDto
    {
        Limite = limite,
        Utilizadas = utilizadas,
        Percentual = percentual,
        AtingiuLimite = limite != -1 && utilizadas >= limite,
        Plano = usuario.Plano.ToString()
    };
    }
}