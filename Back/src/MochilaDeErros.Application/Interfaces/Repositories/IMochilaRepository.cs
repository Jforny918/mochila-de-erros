using MochilaDeErros.Domain.Entities;

namespace MochilaDeErros.Application.Interfaces.Repositories;

public interface IMochilaRepository
{
    Task AddAsync(Mochila mochila);
    Task<List<Mochila>> GetByUserAsync(Guid userId);
    Task<List<Mochila>> GetAllAsync(Guid userId);
    Task<Mochila?> GetByIdAsync(Guid id);
}