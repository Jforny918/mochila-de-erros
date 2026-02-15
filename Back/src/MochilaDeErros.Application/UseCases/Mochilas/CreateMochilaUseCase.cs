using MochilaDeErros.Application.Interfaces.Repositories.Write;
using MochilaDeErros.Domain.Entities;
using MochilaDeErros.Application.DTOs.Mochilas;

namespace MochilaDeErros.Application.UseCases.Mochilas;

public class CreateMochilaUseCase
{
    private readonly IMochilaWriteRepository _repository;

    public CreateMochilaUseCase(IMochilaWriteRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> ExecuteAsync(CreateMochilaRequest request)
    {
        var mochila = new Mochila
        (
            request.UserId,
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