using MochilaDeErros.Domain.Enums;
using MochilaDeErros.Domain.Exceptions;

namespace MochilaDeErros.Domain.Entities;

public class Questao
{
    public Guid Id { get; private set; }
    public Guid MochilaId { get; private set; }

    public string Enunciado { get; private set; } = null!;
    public string? ImagemUrl { get; private set; }
    public string? Explicacao { get; private set; }
    public string? Origem { get; private set; }

    public StatusQuestao Status { get; private set; }
    public DateTime? BloqueadaAte { get; private set; }

    private readonly List<Alternativa> _alternativas = new();
    public IReadOnlyCollection<Alternativa> Alternativas => _alternativas;

    private bool _fechadaParaEdicao;

    private Questao() { }

    public Questao(Guid mochilaId, string enunciado, string? imagemUrl, string? explicacao, string? origem)
    {
        if (string.IsNullOrWhiteSpace(enunciado))
            throw new DomainException("O enunciado da questão é obrigatório.");

        Id = Guid.NewGuid();
        MochilaId = mochilaId;
        Status = StatusQuestao.Pendente;

        Enunciado = enunciado;
        ImagemUrl = imagemUrl;
        Explicacao = explicacao;
        Origem = origem;
    }

    public void AdicionarAlternativa(string letra, string texto, bool ehCorreta)
    {
        if (_fechadaParaEdicao)
            throw new DomainException("A questão já foi finalizada e não pode ser alterada.");

        if (_alternativas.Any(a => a.Letra == letra))
            throw new DomainException($"A alternativa '{letra}' já existe.");

        if (ehCorreta && _alternativas.Any(a => a.EhCorreta))
            throw new DomainException("A questão já possui uma alternativa correta.");

        _alternativas.Add(new Alternativa(Id, letra, texto, ehCorreta));
    }

    

    public void FinalizarCadastro()
    {
        if (_alternativas.Count < 2)
            throw new DomainException("A questão deve ter pelo menos duas alternativas.");

        if (_alternativas.Count(a => a.EhCorreta) != 1)
            throw new DomainException("A questão deve ter exatamente uma alternativa correta.");

        _fechadaParaEdicao = true;
    }

    public void AtualizarDados(string enunciado, string? explicacao, string? origem, string? imagemUrl)
    {
        if (string.IsNullOrWhiteSpace(enunciado))
            throw new DomainException("O enunciado é obrigatório.");

        Enunciado = enunciado;
        Explicacao = explicacao;
        Origem = origem;
        ImagemUrl = imagemUrl;
    }

    public void Responder(string letraMarcada)
    {
        var alternativa = _alternativas
            .FirstOrDefault(a => a.Letra.Equals(letraMarcada, StringComparison.OrdinalIgnoreCase));

        if (alternativa is null)
            throw new DomainException("Alternativa inválida.");

        if (alternativa.EhCorreta)
        {
            MarcarComoDominada();
        }
        else
        {
            BloquearPor(TimeSpan.FromMinutes(30));
        }
    }

    public void MarcarComoDominada()
    {
        Status = StatusQuestao.Dominada;
        BloqueadaAte = null;
    }

    public void BloquearPor(TimeSpan tempo)
    {
        Status = StatusQuestao.Bloqueada;
        BloqueadaAte = DateTime.UtcNow.Add(tempo);
    }

    public void EditarConteudo(
        string enunciado,
        string? explicacao,
        string? origem,
        string? imagemUrl
    )
    {
        if (string.IsNullOrWhiteSpace(enunciado))
            throw new DomainException("O enunciado é obrigatório.");

        Enunciado = enunciado;
        Explicacao = explicacao;
        Origem = origem;
        ImagemUrl = imagemUrl;
    }

    public void AtualizarAlternativas(
    IEnumerable<(string Letra, string Texto, bool EhCorreta)> novasAlternativas)
{
    if (_fechadaParaEdicao)
        throw new DomainException("A questão não pode mais ser editada.");

    if (novasAlternativas.Count() < 2)
        throw new DomainException("A questão deve ter pelo menos duas alternativas.");

    if (novasAlternativas.Count(a => a.EhCorreta) != 1)
        throw new DomainException("A questão deve ter exatamente uma alternativa correta.");

    var letrasNovas = novasAlternativas.Select(a => a.Letra).ToHashSet();

    var paraRemover = _alternativas
        .Where(a => !letrasNovas.Contains(a.Letra))
        .ToList();

    foreach (var alt in paraRemover)
        _alternativas.Remove(alt);

    foreach (var nova in novasAlternativas)
    {
        var existente = _alternativas.FirstOrDefault(a => a.Letra == nova.Letra);

        if (existente is not null)
        {
            existente.Atualizar(nova.Texto, nova.EhCorreta);
        }
        else
        {
            _alternativas.Add(new Alternativa(
                Id,
                nova.Letra,
                nova.Texto,
                nova.EhCorreta
            ));
        }
    }
}

}
