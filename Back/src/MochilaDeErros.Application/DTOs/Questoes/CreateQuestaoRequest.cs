namespace MochilaDeErros.Application.DTOs.Questoes;

public class CreateQuestaoRequest
{
    public string Enunciado { get; set; } = null!;
    public string? ImagemUrl { get; set; }
    public string? Explicacao { get; set; }
    public string? Origem { get; set; }

    public List<CreateAlternativaRequest> Alternativas { get; set; } = [];
}

public class CreateAlternativaRequest
{
    public string Letra { get; set; } = null!;
    public string Texto { get; set; } = null!;
    public bool EhCorreta { get; set; }
}