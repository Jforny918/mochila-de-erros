namespace MochilaDeErros.Application.DTOs.Questoes;

public class UpdateQuestaoRequest
{
    public string Enunciado { get; set; } = null!;
    public string? Explicacao { get; set; }
    public string? Origem { get; set; }
    public string? ImagemUrl { get; set; }
}