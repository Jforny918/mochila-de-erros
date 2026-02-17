using Microsoft.EntityFrameworkCore;
using MochilaDeErros.Application.DTOs.Mochilas;
using MochilaDeErros.Application.Interfaces.Repositories.Read;
using MochilaDeErros.Domain.Enums;
using MochilaDeErros.Infrastructure.Persistence;

namespace MochilaDeErros.Infrastructure.Repositories.Read;

public class MochilaReadRepository : IMochilaReadRepository
{
    private readonly AppDbContext _context;

    public MochilaReadRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<MochilaCardDto>> GetCardsByUserIdAsync(Guid userId)
    {
        
        var mochilas = await _context.Mochilas
            .Include(m => m.Tags)
            .Where(m => m.UserId == userId && m.Ativa)
            .ToListAsync();

        var mochilaIds = mochilas.Select(m => m.Id).ToList();

        var stats = await _context.Questoes
            .Where(q => mochilaIds.Contains(q.MochilaId))
            .GroupBy(q => q.MochilaId)
            .Select(g => new
            {
                MochilaId = g.Key,
                Total = g.Count(),
                Pendentes = g.Count(x => x.Status == StatusQuestao.Pendente),
                Dominadas = g.Count(x => x.Status == StatusQuestao.Dominada)
            })
            .ToListAsync();

        var statsDict = stats.ToDictionary(x => x.MochilaId, x => x);

        return mochilas.Select(m =>
        {
            statsDict.TryGetValue(m.Id, out var s);

            return new MochilaCardDto
            {
                Id = m.Id,
                Nome = m.Nome,
                Descricao = m.Descricao,
                Cor = m.Cor,
                Tags = m.Tags.Select(t => t.Nome).ToList(),

                TotalQuestoes = s?.Total ?? 0,
                Pendentes = s?.Pendentes ?? 0,
                Dominadas = s?.Dominadas ?? 0,

                PeriodoRevisao = TraduzirFrequencia(m.FrequenciaRevisao),
                Bloqueada = false
            };
        }).ToList();
    }

    private static string TraduzirFrequencia(FrequenciaRevisao frequencia)
    {
        return frequencia switch
        {
            FrequenciaRevisao.Diaria => "Diariamente",
            FrequenciaRevisao.Semanal => "Semanalmente",
            FrequenciaRevisao.Quinzenal => "Quinzenalmente",
            FrequenciaRevisao.Mensal => "Mensalmente",
            _ => "Indefinido"
        };
    }

    public async Task<bool> ExistsByUserAsync(Guid userId, Guid mochilaId)
    {
        return await _context.Mochilas.AsNoTracking()
            .AnyAsync(m => m.Id == mochilaId && m.UserId == userId && m.Ativa);
    }
}