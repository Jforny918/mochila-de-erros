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
    modelBuilder.Entity<Usuario>(builder =>
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.DataCriacao)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasMany(u => u.Mochilas)
            .WithOne(m => m.Usuario)
            .HasForeignKey(m => m.UsuarioId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    });

    modelBuilder.Entity<Mochila>(builder =>
    {
        builder.HasKey(m => m.Id);

        builder.Property(m => m.CriadaEm)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
    });

    base.OnModelCreating(modelBuilder);
}

}