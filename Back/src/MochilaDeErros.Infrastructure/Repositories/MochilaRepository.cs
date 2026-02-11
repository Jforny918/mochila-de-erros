using Microsoft.EntityFrameworkCore;
using MochilaDeErros.Application.Interfaces.Repositories;
using MochilaDeErros.Domain.Entities;
using MochilaDeErros.Infrastructure.Persistence;

namespace MochilaDeErros.Infrastructure.Repositories;

public class MochilaRepository : IMochilaRepository
{
    private readonly AppDbContext _context;

    public MochilaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Mochila mochila)
    {
        _context.Mochilas.Add(mochila);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Mochila>> GetByUserAsync(Guid userId)
    {
        return await _context.Mochilas
            .Include(x => x.Tags)
            .Where(x => x.UserId == userId)
            .ToListAsync();
    }

    public async Task<List<Mochila>> GetAllAsync(Guid userId)
    {
        return await _context.Mochilas
            .Include(m => m.Tags)
            .Where(m => m.UserId == userId && m.Ativa)
            .ToListAsync();
    }

    public async Task<Mochila?> GetByIdAsync(Guid id)
    {
        return await _context.Mochilas
            .Include(x => x.Tags)
            .FirstOrDefaultAsync(x => x.Id == id);
    }


}