using MochilaDeErros.Application.DTOs.Questoes;
using MochilaDeErros.Application.Interfaces.Repositories;

public class GetQuestaoByIdUseCase
{
    private readonly IQuestaoRepository _repository;

    public GetQuestaoByIdUseCase(IQuestaoRepository repository)
    {
        _repository = repository;
    }

    public async Task<QuestaoResponse?> ExecuteAsync(Guid id)
    {
        var q = await _repository.GetByIdAsync(id);
        if (q is null) return null;

        return new QuestaoResponse
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
        };
    }
}
