namespace MochilaDeErros.Application.DTOs.Questoes;

public class ResponderQuestaoResponse
{
    public bool Acertou { get; set; }
    public string LetraCorreta { get; set; } = null!;
    public string? Explicacao { get; set; }
    public string StatusAtual { get; set; } = null!;
    public DateTime? BloqueadaAte { get; set; }
}
