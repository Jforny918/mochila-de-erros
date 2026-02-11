using MochilaDeErros.Application.DTOs.Questoes;
using MochilaDeErros.Application.Interfaces.Repositories;

namespace MochilaDeErros.Application.UseCases.Questoes;

public class UpdateQuestaoUseCase
{
    private readonly IQuestaoRepository _repository;

    public UpdateQuestaoUseCase(IQuestaoRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(Guid id, UpdateQuestaoRequest request)
    {
        var questao = await _repository.GetByIdAsync(id);

        if (questao is null)
            throw new Exception("Questão não encontrada.");

        questao.AtualizarDados(
            request.Enunciado,
            request.Explicacao,
            request.Origem,
            request.ImagemUrl
        );

        await _repository.SaveChangesAsync();
    }
}
