namespace MochilaDeErros.Domain.Entities;

public class MochilaTag
{
    public Guid Id { get; private set; }
    public Guid MochilaId { get; private set; }
    public string Nome { get; private set; } = null!;

    private MochilaTag() { }

    public MochilaTag(Guid mochilaId, string nome)
    {
        Id = Guid.NewGuid();
        MochilaId = mochilaId;
        Nome = nome;
    }
}