using MochilaDeErros.Application.DTOs.Mochilas;

namespace MochilaDeErros.Application.Interfaces.Repositories.Read;

public interface IMochilaReadRepository
{

    Task<bool> ExistsByUserAsync(Guid userId, Guid mochilaId);
    Task<List<MochilaCardDto>> GetCardsByUserIdAsync(Guid userId);
}