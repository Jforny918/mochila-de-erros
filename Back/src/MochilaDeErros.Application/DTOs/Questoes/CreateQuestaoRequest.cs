namespace MochilaDeErros.Application.DTOs.Questoes;

public class CreateQuestaoRequest
{
    public Guid UserId { get; set; }
    public Guid MochilaId { get; set; }

    public string Enunciado { get; set; } = null!;
    public string? ImagemUrl { get; set; }
    public string? Explicacao { get; set; }
    public string? Origem { get; set; }
}