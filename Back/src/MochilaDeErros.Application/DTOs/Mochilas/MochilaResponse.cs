namespace MochilaDeErros.Application.DTOs.Mochilas;

public class MochilaResponse
{
    public Guid Id { get;  init; }
    public string Nome { get; init; } = null!;
    public string? Descricao { get; init; }
    public string Cor { get; init; } = null!;
    public int FrequenciaRevisao { get; init; }
    public bool Ativa { get; init; }
    public DateTime CriadaEm { get; init; }
    public List<string> Tags { get; init; } = [];
}