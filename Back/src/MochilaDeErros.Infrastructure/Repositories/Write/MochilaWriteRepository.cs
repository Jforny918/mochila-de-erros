using MochilaDeErros.Application.Interfaces.Repositories.Write;
using MochilaDeErros.Domain.Entities;
using MochilaDeErros.Infrastructure.Persistence;

namespace MochilaDeErros.Infrastructure.Repositories.Write;

public class MochilaWriteRepository : IMochilaWriteRepository
{
    private readonly AppDbContext _context;

    public MochilaWriteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Mochila mochila)
    {
        await _context.Mochilas.AddAsync(mochila);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
