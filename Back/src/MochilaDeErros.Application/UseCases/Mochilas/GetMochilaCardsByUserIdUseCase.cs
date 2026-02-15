using MochilaDeErros.Application.DTOs.Mochilas;
using MochilaDeErros.Application.Interfaces.Repositories.Read;

namespace MochilaDeErros.Application.UseCases.Mochilas;

public class GetMochilaCardsByUserIdUseCase
{
    private readonly IMochilaReadRepository _repo;

    public GetMochilaCardsByUserIdUseCase(IMochilaReadRepository repo)
    {
        _repo = repo;
    }

    public Task<List<MochilaCardDto>> ExecuteAsync(Guid userId)
        => _repo.GetCardsByUserIdAsync(userId);
}
