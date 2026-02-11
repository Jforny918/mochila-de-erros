using MochilaDeErros.Domain.Entities;

namespace MochilaDeErros.Application.Interfaces.Repositories;

public interface IQuestaoRepository
{
    Task AddAsync(Questao questao);
    Task<List<Questao>> GetByMochilaAsync(Guid mochilaId);
    Task<List<Questao>> GetByMochilaIdAsync(Guid mochilaId);
    Task<Questao?> GetByIdAsync(Guid id);
    Task UpdateAsync(Questao questao);
    Task SaveChangesAsync();

}