using MochilaDeErros.Domain.Entities;

namespace MochilaDeErros.Application.Interfaces.Repositories.Write;

public interface IQuestaoWriteRepository
{
    Task AddAsync(Questao questao);
    Task SaveChangesAsync();
}
