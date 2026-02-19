using MochilaDeErros.Application.Interfaces.Repositories.Write;
using MochilaDeErros.Domain.Entities;
using MochilaDeErros.Application.DTOs.Mochilas;

namespace MochilaDeErros.Application.UseCases.Mochilas;

public class CreateMochilaUseCase
{
    private readonly IMochilaWriteRepository _repository;
    private readonly IUsuarioReadRepository _usuarioReadRepository;

    public CreateMochilaUseCase(
        IMochilaWriteRepository repository,
        IUsuarioReadRepository usuarioReadRepository)
    {
        _repository = repository;
        _usuarioReadRepository = usuarioReadRepository;
    }

    public async Task<Guid> ExecuteAsync(CreateMochilaRequest request)
    {
        var usuario = await _usuarioReadRepository
            .ObterComMochilasAsync(request.UsuarioId);

        if (usuario is null)
            throw new Exception("Usuário não encontrado.");

        if(!usuario.PodeCriarMochila())
            throw new Exception("Limite de mochilas atingido para o plano atual.");

        var mochila = new Mochila
        (
            request.UsuarioId,
            request.Nome,
            request.Cor,
            request.FrequenciaRevisao,
            request.Descricao
        );

        foreach (var tag in request.Tags)
        {
            mochila.AdicionarTag(tag);
        }

        await _repository.AddAsync(mochila);
        await _repository.SaveChangesAsync();

        return mochila.Id;
    }
}