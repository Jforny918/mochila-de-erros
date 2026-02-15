public class MochilaCardDto
{
    public Guid Id { get; set; }

    public string Nome { get; set; } = null!;
    public string? Descricao { get; set; }
    public string Cor { get; set; } = null!;
    public List<string> Tags { get; set; } = new();

    public int TotalQuestoes { get; set; }
    public int Pendentes { get; set; }
    public int Dominadas { get; set; }

    public string PeriodoRevisao { get; set; } = null!;
    public bool Bloqueada { get; set; }
}