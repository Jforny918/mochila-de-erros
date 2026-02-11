using Microsoft.EntityFrameworkCore;
using MochilaDeErros.Domain.Entities;

namespace MochilaDeErros.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Mochila> Mochilas => Set<Mochila>();
    public DbSet<MochilaTag> MochilaTags => Set<MochilaTag>();
    public DbSet<Questao> Questoes => Set<Questao>();
    public DbSet<Alternativa> Alternativas => Set<Alternativa>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
