namespace MochilaDeErros.Application.DTOs.Usuarios;
public class UsoPlanoDto
{
    public int Limite { get; set; }
    public int Utilizadas { get; set; }
    public double Percentual { get; set; }
    public bool AtingiuLimite { get; set; }
    public string Plano { get; set; } = string.Empty;
}


