namespace MochilaDeErros.Application.DTOs.Questoes;

public class ProximaQuestaoResponse
{
    public Guid Id { get; set; }
    public string Enunciado { get; set; } = null!;
    public string? ImagemUrl { get; set; }
    public string? Origem { get; set; }

    public List<AlternativaResponse> Alternativas { get; set; } = [];
}
