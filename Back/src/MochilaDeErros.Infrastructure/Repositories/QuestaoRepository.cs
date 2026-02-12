using Microsoft.EntityFrameworkCore;
using MochilaDeErros.Application.Interfaces.Repositories;
using MochilaDeErros.Domain.Entities;
using MochilaDeErros.Infrastructure.Persistence;
using MochilaDeErros.Domain.Enums;

namespace MochilaDeErros.Infrastructure.Repositories;

public class QuestaoRepository : IQuestaoRepository
{
    private readonly AppDbContext _context;

    public QuestaoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Questao questao)
    {
        await _context.Questoes.AddAsync(questao);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Questao>> GetByMochilaAsync(Guid mochilaId)
    {
        return await _context.Questoes
            .Include(q => q.Alternativas)
            .Where(q => q.MochilaId == mochilaId && q.Status != Domain.Enums.StatusQuestao.Bloqueada)
            .ToListAsync();
    }

    public async Task<List<Questao>> GetByMochilaIdAsync(Guid mochilaId)
    {
        return await _context.Questoes
            .Include(q => q.Alternativas)
            .Where(q => q.MochilaId == mochilaId)
            .ToListAsync();
    }

    public async Task<Questao?> GetByIdAsync(Guid id)
    {
        return await _context.Questoes
            .Include(q => q.Alternativas)
            .FirstOrDefaultAsync(q => q.Id == id);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Questao questao)
    {
        _context.Questoes.Update(questao);
        await _context.SaveChangesAsync();
    }

    public async Task<Questao?> GetProximaQuestaoAsync(Guid mochilaId)
    {
        return await _context.Questoes
            .Include(q => q.Alternativas)
            .Where(q =>
                q.MochilaId == mochilaId && q.Status == StatusQuestao.Pendente &&
                (q.BloqueadaAte == null || q.BloqueadaAte <= DateTime.UtcNow)
                )
                .OrderBy(q => q.Id)
                .FirstOrDefaultAsync();
    }

}