using MochilaDeErros.Application.DTOs.Mochilas;
using MochilaDeErros.Application.Interfaces.Repositories;
using MochilaDeErros.Domain.Entities;

namespace MochilaDeErros.Application.UseCases.Mochilas;

public class CreateMochilaUseCase
{
    private readonly IMochilaRepository _repository;

    public CreateMochilaUseCase(IMochilaRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> ExecuteAsync(CreateMochilaRequest request)
    {
        var mochila = new Mochila(
            request.UserId,
            request.Nome,
            request.Cor,
            request.FrequenciaRevisao,
            request.Descricao
        );

        foreach (var tag in request.Tags)
            mochila.AdicionarTag(tag);

        await _repository.AddAsync(mochila);
        return mochila.Id;
    }
}
