using MochilaDeErros.Application.DTOs.Usuarios;
using MochilaDeErros.Application.Interfaces;
using MochilaDeErros.Domain.Entities;
using MochilaDeErros.Application.Interfaces.Repositories.Write;

namespace MochilaDeErros.Application.UseCases.Usuarios;

public class CreateUsuarioUseCase
{
    private readonly IUsuarioWriteRepository _usuarioWriteRepository;
    public CreateUsuarioUseCase(IUsuarioWriteRepository usuarioWriteRepository)
    {
        _usuarioWriteRepository = usuarioWriteRepository;
    }
    public async Task<Guid> ExecuteAsync (CreateUsuarioDto dto)
    {
        var usuario = new Usuario (dto.Nome, dto.Email);

        await _usuarioWriteRepository.AddAsync(usuario);
        await _usuarioWriteRepository.SaveChangesAsync();

        return usuario.Id;
    }
}