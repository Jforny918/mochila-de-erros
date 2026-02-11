using MochilaDeErros.Application.DTOs.Mochilas;
using MochilaDeErros.Application.Interfaces.Repositories;

namespace MochilaDeErros.Application.UseCases.Mochilas;

public class GetMochilaByIdUseCase
{
    private readonly IMochilaRepository _repository;

    public GetMochilaByIdUseCase(IMochilaRepository repository)
    {
        _repository = repository;
    }

    public async Task<MochilaResponse?> ExecuteAsync(Guid id)
    {
        var m = await _repository.GetByIdAsync(id);
        if (m is null) return null;

        return new MochilaResponse
        {
            Id = m.Id,
            Nome = m.Nome,
            Descricao = m.Descricao,
            Cor = m.Cor,
            FrequenciaRevisao = (int)m.FrequenciaRevisao,
            CriadaEm = m.CriadaEm,
            Ativa = m.Ativa,
            Tags = m.Tags.Select(t => t.Nome).ToList()
        };
    }
}