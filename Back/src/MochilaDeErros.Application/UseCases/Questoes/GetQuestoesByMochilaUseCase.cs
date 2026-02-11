using MochilaDeErros.Application.DTOs.Questoes;
using MochilaDeErros.Application.Interfaces.Repositories;

public class GetQuestoesByMochilaUseCase
{
    private readonly IQuestaoRepository _repository;

    public GetQuestoesByMochilaUseCase(IQuestaoRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<QuestaoResponse>> ExecuteAsync(Guid mochilaId)
    {
        var questoes = await _repository.GetByMochilaIdAsync(mochilaId);

        return questoes.Select(q => new QuestaoResponse
        {
            Id = q.Id,
            Enunciado = q.Enunciado,
            Explicacao = q.Explicacao,
            Origem = q.Origem,
            Alternativas = q.Alternativas.Select(a => new AlternativaResponse
            {
                Letra = a.Letra,
                Texto = a.Texto,
                EhCorreta = a.EhCorreta
            }).ToList()
        }).ToList();
    }
}