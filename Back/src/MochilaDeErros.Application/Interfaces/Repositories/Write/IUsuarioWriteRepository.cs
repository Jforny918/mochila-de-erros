using MochilaDeErros.Domain.Entities;

namespace MochilaDeErros.Application.Interfaces.Repositories.Write;
public interface IUsuarioWriteRepository
{
    Task AddAsync(Usuario usuario);
    Task SaveChangesAsync();
}