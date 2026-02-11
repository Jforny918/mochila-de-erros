namespace MochilaDeErros.Domain.Entities;

public class Alternativa
{
    public Guid Id { get; private set; }
    public Guid QuestaoId { get; private set; }

    public string Letra { get; private set; } = null!;
    public string Texto { get; private set; } = null!;
    public bool EhCorreta { get; private set; }

    private Alternativa() { }

    internal Alternativa(Guid questaoId, string letra, string texto, bool ehCorreta)
    {
        Id = Guid.NewGuid();
        QuestaoId = questaoId;
        Letra = letra;
        Texto = texto;
        EhCorreta = ehCorreta;
    }
}
