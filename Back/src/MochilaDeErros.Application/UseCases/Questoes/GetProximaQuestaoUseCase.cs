using MochilaDeErros.Application.DTOs.Questoes;
using MochilaDeErros.Application.Interfaces.Repositories;

namespace MochilaDeErros.Application.UseCases.Questoes;

public class GetProximaQuestaoUseCase
{
    private readonly IQuestaoRepository _repository;

    public GetProximaQuestaoUseCase(IQuestaoRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProximaQuestaoResponse?> ExecuteAsync(Guid mochilaId)
    {
        var questao = await _repository.GetProximaQuestaoAsync(mochilaId);
        if (questao is null) return null;

        return new ProximaQuestaoResponse
        {
            Id = questao.Id,
            Enunciado = questao.Enunciado,
            ImagemUrl = questao.ImagemUrl,
            Origem = questao.Origem,
            Alternativas = questao.Alternativas
                .Select(a => new AlternativaResponse
                {
                    Letra = a.Letra,
                    Texto = a.Texto
                })
                .ToList()
        };
    }
}
