using MochilaDeErros.Application.DTOs.Mochilas;

namespace MochilaDeErros.Application.Interfaces.Repositories.Read;

public interface IMochilaReadRepository
{
    Task<List<MochilaCardDto>> GetCardsByUserIdAsync(Guid userId);
}