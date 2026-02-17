using MochilaDeErros.Application.DTOs.Questoes;
using MochilaDeErros.Application.Interfaces.Repositories;
using MochilaDeErros.Application.Interfaces.Repositories.Read;

namespace MochilaDeErros.Application.UseCases.Questoes;

public class GetQuestoesCardsByMochilaIdUseCase
{
    private readonly IQuestaoReadRepository _repository;

    public GetQuestoesCardsByMochilaIdUseCase(IQuestaoReadRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<QuestaoCardDto>> ExecuteAsync(Guid userId, Guid mochilaId)
    {
        return await _repository.GetCardsByMochilaIdAsync(userId, mochilaId);
    }
}