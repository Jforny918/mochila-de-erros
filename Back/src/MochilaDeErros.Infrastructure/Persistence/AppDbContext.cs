using Microsoft.EntityFrameworkCore;
using MochilaDeErros.Domain.Entities;

namespace MochilaDeErros.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<Mochila> Mochilas => Set<Mochila>();
    public DbSet<MochilaTag> MochilaTags => Set<MochilaTag>();
    public DbSet<Questao> Questoes => Set<Questao>();
    public DbSet<Alternativa> Alternativas => Set<Alternativa>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Questao>(builder =>
    {
        builder.HasKey(q => q.Id);

        builder.Property(q => q.MochilaId)
               .IsRequired();

        builder.HasMany(q => q.Alternativas)
               .WithOne()
               .HasForeignKey(a => a.QuestaoId)
               .OnDelete(DeleteBehavior.Cascade);
    });

        modelBuilder.Entity<Alternativa>(builder =>
    {
        builder.HasKey(a => a.Id);
    });

        modelBuilder.Entity<Usuario>()
        .Property(u => u.Plano)
        .HasConversion<int>();

        base.OnModelCreating(modelBuilder);
    }
}
