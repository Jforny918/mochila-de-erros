using Microsoft.EntityFrameworkCore;
using MochilaDeErros.Application.Interfaces;
using MochilaDeErros.Domain.Entities;
using MochilaDeErros.Infrastructure.Persistence;
using MochilaDeErros.Application.Interfaces.Repositories.Write;

public class UsuarioWriteRepository : IUsuarioWriteRepository
{
    private readonly AppDbContext _context;

    public UsuarioWriteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Usuario usuario)
    {
        await _context.Usuarios.AddAsync(usuario);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}