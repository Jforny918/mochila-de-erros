using MochilaDeErros.Application.DTOs.Mochilas;
using MochilaDeErros.Application.Interfaces.Repositories.Read;

namespace MochilaDeErros.Application.UseCases.Mochilas;

public class GetMochilasByUserIdUseCase
{
    private readonly IMochilaReadRepository _repository;

    public GetMochilasByUserIdUseCase(IMochilaReadRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<MochilaCardDto>> ExecuteAsync(Guid userId)
    {
        return await _repository.GetCardsByUserIdAsync(userId);
    }
}