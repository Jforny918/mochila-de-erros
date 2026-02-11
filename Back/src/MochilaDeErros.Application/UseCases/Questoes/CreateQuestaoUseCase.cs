using MochilaDeErros.Application.DTOs.Questoes;
using MochilaDeErros.Application.Interfaces.Repositories;
using MochilaDeErros.Domain.Entities;

namespace MochilaDeErros.Application.UseCases.Questoes;

public class CreateQuestaoUseCase
{
    private readonly IQuestaoRepository _repository;

    public CreateQuestaoUseCase(IQuestaoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> ExecuteAsync(Guid mochilaId, CreateQuestaoRequest request)
    {
        var questao = new Questao(
            mochilaId,
            request.Enunciado,
            request.ImagemUrl,
            request.Explicacao,
            request.Origem
        );

        foreach (var alt in request.Alternativas)
            questao.AdicionarAlternativa(alt.Letra, alt.Texto, alt.EhCorreta);

        questao.FinalizarCadastro();

        await _repository.AddAsync(questao);

        return questao.Id;
    }
}