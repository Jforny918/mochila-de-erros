using MochilaDeErros.Domain.Enums;

namespace MochilaDeErros.Application.DTOs.Mochilas;

public class MochilaDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = null!;
    public string? Descricao { get; set; }
    public string Cor { get; set; } = null!;
    public FrequenciaRevisao FrequenciaRevisao { get; set; }
    public int TotalQuestoes { get; set; }
    public int Pendentes { get; set; }
    public int Dominadas { get; set; }
}