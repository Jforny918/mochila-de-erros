using MochilaDeErros.Domain.Entities;
using MochilaDeErros.Application.Interfaces.Repositories.Write;
using MochilaDeErros.Infrastructure.Persistence;

public class QuestaoWriteRepository : IQuestaoWriteRepository
{
    private readonly AppDbContext _context;

    public QuestaoWriteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Questao questao)
    {
        await _context.Questoes.AddAsync(questao);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}