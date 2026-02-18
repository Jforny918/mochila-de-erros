using MochilaDeErros.Domain.Entities;

public interface IUsuarioReadRepository
{
    Task<Usuario?> ObterComMochilasAsync(Guid usuarioId);
}