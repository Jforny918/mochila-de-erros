using MochilaDeErros.Domain.Enums;
using MochilaDeErros.Domain.Exceptions;

namespace MochilaDeErros.Domain.Entities;

public class Mochila
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }

    public string Nome { get; private set; } = null!;
    public string? Descricao { get; private set; }
    public string Cor { get; private set; } = null!;
    public FrequenciaRevisao FrequenciaRevisao { get; private set; }

    public DateTime CriadaEm { get; private set; }
    public bool Ativa { get; private set; }

    private readonly List<MochilaTag> _tags = new();
    public IReadOnlyCollection<MochilaTag> Tags => _tags;

    private Mochila() { }

    public Mochila(Guid userId, string nome, string cor, FrequenciaRevisao frequenciaRevisao, string? descricao = null)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        CriadaEm = DateTime.UtcNow;
        Ativa = true;

        AlterarDados(nome, descricao, cor, frequenciaRevisao);
    }

    public void AlterarDados(string nome, string? descricao, string cor, FrequenciaRevisao frequenciaRevisao)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new DomainException("O nome da mochila é obrigatório.");
        
        Nome = nome;
        Descricao = descricao;
        Cor = cor;
        FrequenciaRevisao = frequenciaRevisao;
    }

    public void AdicionarTag(string nome)
    {
        if(_tags.Any(t => t.Nome == nome))
            return;
        
        _tags.Add(new MochilaTag(Id, nome));
    }
}