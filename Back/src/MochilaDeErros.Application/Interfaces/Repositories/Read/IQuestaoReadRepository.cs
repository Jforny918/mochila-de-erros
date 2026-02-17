using MochilaDeErros.Application.DTOs.Questoes;
using MochilaDeErros.Domain.Entities;
namespace MochilaDeErros.Application.Interfaces.Repositories;

public interface IQuestaoReadRepository
{
    Task<List<QuestaoCardDto>> GetCardsByMochilaIdAsync(Guid userId, Guid mochilaId);
}