namespace MochilaDeErros.Application.DTOs.Questoes;

public class QuestaoResponse
{
    public Guid Id { get; set; }
    public string Enunciado { get; set; } = null!;
    public string? Explicacao { get; set; }
    public string? Origem { get; set; }

    public List<AlternativaResponse> Alternativas { get; set; } = new();
}

public class AlternativaResponse
{
    public string Letra { get; set; } = null!;
    public string Texto { get; set; } = null!;
    public bool EhCorreta { get; set; }
}
