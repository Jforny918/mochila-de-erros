using MochilaDeErros.Application.DTOs.Questoes;
using MochilaDeErros.Application.Interfaces.Repositories.Read;
using MochilaDeErros.Application.Interfaces.Repositories.Write;
using MochilaDeErros.Domain.Entities;
using MochilaDeErros.Domain.Exceptions;

public class CreateQuestaoUseCase
{
    private readonly IMochilaReadRepository _mochilaReadRepository;
    private readonly IQuestaoWriteRepository _questaoWriteRepository;

    public CreateQuestaoUseCase(
        IMochilaReadRepository mochilaReadRepository,
        IQuestaoWriteRepository questaoWriteRepository)
    {
        _mochilaReadRepository = mochilaReadRepository;
        _questaoWriteRepository = questaoWriteRepository;
    }

    public async Task<Guid> ExecuteAsync(CreateQuestaoRequest request)
    {
        var mochilaExists = await _mochilaReadRepository
            .ExistsByUserAsync(request.UserId, request.MochilaId);

        if (!mochilaExists)
            throw new DomainException("Mochila não encontrada para este usuário.");

        var questao = new Questao(
            request.MochilaId,
            request.Enunciado,
            request.ImagemUrl,
            request.Explicacao,
            request.Origem
        );

        await _questaoWriteRepository.AddAsync(questao);
        await _questaoWriteRepository.SaveChangesAsync();

        return questao.Id;
    }
}
