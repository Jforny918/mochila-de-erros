using MochilaDeErros.Domain.Entities;
namespace MochilaDeErros.Application.Interfaces.Repositories;

public interface IQuestaoReadRepository
{
    Task<Questao?> GetByIdAsync(Guid id);
    Task<List<Questao>> GetByMochilaAsync(Guid mochilaId);
    Task<List<Questao>> GetByMochilaIdAsync(Guid mochilaId);
    Task<Questao?> GetProximaQuestaoAsync(Guid mochilaId);

    Task<int> ContarTotalAsync(Guid mochilaId);
    Task<int> ContarPendentesAsync(Guid mochilaId);
    Task<int> ContarDominadasAsync(Guid mochilaId);
}