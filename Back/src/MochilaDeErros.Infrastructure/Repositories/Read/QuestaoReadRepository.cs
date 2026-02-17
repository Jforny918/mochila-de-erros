using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MochilaDeErros.Application.DTOs.Questoes;
using MochilaDeErros.Application.Interfaces.Repositories;
using MochilaDeErros.Application.Interfaces.Repositories.Read;
using MochilaDeErros.Infrastructure.Persistence;

public class QuestaoReadRepository : IQuestaoReadRepository
{
    private readonly AppDbContext _context;

    public QuestaoReadRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<QuestaoCardDto>> GetCardsByMochilaIdAsync(Guid userId, Guid mochilaId)
    {
        return await _context.Questoes
            .Where(q => 
                q.MochilaId == mochilaId &&
                _context.Mochilas.Any(m => 
                    m.Id == mochilaId &&
                    m.UserId == userId &&
                    m.Ativa
                    )
                )
                .Select(q => new QuestaoCardDto
                {
                    Id = q.Id,
                    Enunciado = q.Enunciado,
                    Status = q.Status.ToString(),
                    Bloqueada = q.BloqueadaAte.HasValue &&
                                q.BloqueadaAte > DateTime.UtcNow
                })
                .ToListAsync();
    }
}