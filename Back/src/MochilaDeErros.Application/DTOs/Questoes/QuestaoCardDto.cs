namespace MochilaDeErros.Application.DTOs.Questoes;

public class QuestaoCardDto
{
    public Guid Id { get; set; }
    public string Enunciado { get; set; } = null!;
    public string Status { get; set; } = null!;
    public bool Bloqueada { get; set; }

}