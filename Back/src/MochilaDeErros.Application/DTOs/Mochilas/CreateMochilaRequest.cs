using MochilaDeErros.Domain.Enums;

namespace MochilaDeErros.Application.DTOs.Mochilas;

public class CreateMochilaRequest
{
    public Guid UserId { get; set; } 
    
    public string Nome { get; set; } = null!;
    public string? Descricao { get; set; }
    public string Cor { get; set; } = null!;

    public FrequenciaRevisao FrequenciaRevisao { get; set; }

    public List<string> Tags { get; set; } = new();
}