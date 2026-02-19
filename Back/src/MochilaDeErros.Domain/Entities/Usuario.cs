using MochilaDeErros.Domain.Enums;
using MochilaDeErros.Domain.Entities;
namespace MochilaDeErros.Domain.Entities;

public class Usuario
{
    public Guid Id { get; set; }
    public string Nome { get; set; }=null!;
    public string Email { get; set; }=null!;
    public PlanoTipo Plano { get; set; } = PlanoTipo.Gratuito;
    public DateTime DataCriacao { get; private set; }
    private readonly List<Mochila> _mochilas = new();

    public IReadOnlyCollection<Mochila> Mochilas => _mochilas;
    protected Usuario() { } // EF
    public Usuario(string nome, string email)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Email = email;
        DataCriacao = DateTime.UtcNow;
        Plano = PlanoTipo.Gratuito;
    }
    public bool PodeCriarMochila()
{
    if (Plano == PlanoTipo.Gratuito)
        return Mochilas.Count < 5;

    return true;
}

    public void AlterarPlano(PlanoTipo novoPlano)
    {
        Plano = novoPlano;
    }

}