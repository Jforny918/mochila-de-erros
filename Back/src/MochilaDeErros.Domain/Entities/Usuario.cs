using MochilaDeErros.Domain.Enums;
using MochilaDeErros.Domain.Entities;
namespace MochilaDeErros.Domain.Entities;

public class Usuario
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Nome { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public PlanoTipo Plano { get; private set; } = PlanoTipo.Gratuito;
    public DateTime DataCriacao { get; private set; } = DateTime.UtcNow;

    private readonly List<Mochila> _mochilas = new();
    public IReadOnlyCollection<Mochila> Mochilas => _mochilas;

    protected Usuario() { }

    public Usuario(string nome, string email)
    {
        Nome = nome;
        Email = email;
    }

    public bool PodeCriarMochila()
    {
        return Plano switch
        {
            PlanoTipo.Gratuito => Mochilas.Count < 5,
            PlanoTipo.Premium => Mochilas.Count < 20,
            PlanoTipo.Empresarial => true,
            _ => false
        };
    }

    public void AlterarPlano(PlanoTipo novoPlano)
    {
        Plano = novoPlano;
    }
}
