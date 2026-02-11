using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MochilaDeErros.Application.Interfaces.Repositories;
using MochilaDeErros.Infrastructure.Persistence;
using MochilaDeErros.Infrastructure.Repositories;

namespace MochilaDeErros.Infrastructure.DependencyInjection;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        string connectionString)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(connectionString));

        services.AddScoped<IMochilaRepository, MochilaRepository>();
        services.AddScoped<IQuestaoRepository, QuestaoRepository>();

        return services;
    }
}
