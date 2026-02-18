using Microsoft.EntityFrameworkCore;
using MochilaDeErros.Domain.Entities;
using MochilaDeErros.Application.Interfaces.Repositories.Read;
using MochilaDeErros.Infrastructure.Persistence;
public class UsuarioReadRepository : IUsuarioReadRepository
{
    private readonly AppDbContext _context;

    public UsuarioReadRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Usuario?> ObterComMochilasAsync(Guid usuarioId)
    {
        return await _context.Usuarios
            .Include(u => u.Mochilas)
            .FirstOrDefaultAsync(u => u.Id == usuarioId);
    }
}
