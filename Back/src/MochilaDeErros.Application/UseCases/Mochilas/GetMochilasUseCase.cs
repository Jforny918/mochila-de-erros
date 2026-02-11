using MochilaDeErros.Application.DTOs.Mochilas;
using MochilaDeErros.Application.Interfaces.Repositories;

namespace MochilaDeErros.Application.UseCases.Mochilas;

public class GetMochilasUseCase
{
    private readonly IMochilaRepository _repository;

    public GetMochilasUseCase(IMochilaRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<MochilaResponse>> ExecuteAsync(Guid userId)
    {
        var mochilas = await _repository.GetAllAsync(userId);

        return mochilas.Select(m => new MochilaResponse
        {
            Id = m.Id,
            Nome = m.Nome,
            Descricao = m.Descricao,
            Cor = m.Cor,
            FrequenciaRevisao = (int)m.FrequenciaRevisao,
            CriadaEm = m.CriadaEm,
            Ativa = m.Ativa,
            Tags = m.Tags.Select(t => t.Nome).ToList()
        }).ToList();
    }
}