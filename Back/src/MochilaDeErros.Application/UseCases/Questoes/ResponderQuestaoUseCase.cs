using MochilaDeErros.Application.DTOs.Questoes;
using MochilaDeErros.Application.Interfaces.Repositories;
using MochilaDeErros.Domain.Enums;

namespace MochilaDeErros.Application.UseCases.Questoes;

public class ResponderQuestaoUseCase
{
    private readonly IQuestaoRepository _repository;

    public ResponderQuestaoUseCase(IQuestaoRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResponderQuestaoResponse?> ExecuteAsync(Guid questaoId, string letraMarcada)
    {
        var questao = await _repository.GetByIdAsync(questaoId);
        if (questao is null) return null;

        var correta = questao.Alternativas.First(a => a.EhCorreta);

        bool acertou = correta.Letra.Equals(letraMarcada, StringComparison.OrdinalIgnoreCase);

        if (acertou)
            questao.MarcarComoDominada();
        else
            questao.BloquearPor(TimeSpan.FromMinutes(10));

        await _repository.UpdateAsync(questao);

        return new ResponderQuestaoResponse
        {
            Acertou = acertou,
            LetraCorreta = correta.Letra,
            Explicacao = questao.Explicacao,
            StatusAtual = questao.Status.ToString(),
            BloqueadaAte = questao.BloqueadaAte
        };
    }
}
