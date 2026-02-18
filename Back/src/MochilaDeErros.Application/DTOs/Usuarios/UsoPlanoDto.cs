namespace MochilaDeErros.Application.DTOs.Usuarios;
public class UsoPlanoDto
{
   public int Limite {get; set;}
   public int Utilizadas { get; set; }
   public int Restantes => Limite - Utilizadas;
    public double Percentual => Limite == 0 
        ? 0 
        : (double)Utilizadas / Limite * 100;
   public bool AtingiuLimite => Utilizadas >= Limite;

}

