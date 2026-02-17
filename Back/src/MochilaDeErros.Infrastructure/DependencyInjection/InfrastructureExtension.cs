using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MochilaDeErros.Infrastructure.Persistence;
using MochilaDeErros.Application.Interfaces.Repositories.Read;
using MochilaDeErros.Infrastructure.Repositories.Read;
using MochilaDeErros.Application.Interfaces.Repositories.Write;
using MochilaDeErros.Infrastructure.Repositories.Write;
using MochilaDeErros.Application.UseCases.Mochilas;
using MochilaDeErros.Application.UseCases.Questoes;
using MochilaDeErros.Application.Interfaces.Repositories;

namespace MochilaDeErros.Infrastructure.DependencyInjection;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlite(
                configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped<IMochilaReadRepository, MochilaReadRepository>();
        services.AddScoped<IMochilaWriteRepository, MochilaWriteRepository>();
        services.AddScoped<IQuestaoWriteRepository, QuestaoWriteRepository>();
        services.AddScoped<IQuestaoReadRepository, QuestaoReadRepository>();
        services.AddScoped<GetMochilaCardsByUserIdUseCase>();
        services.AddScoped<CreateMochilaUseCase>();
        services.AddScoped<IQuestaoReadRepository, QuestaoReadRepository>();
        services.AddScoped<GetQuestoesCardsByMochilaIdUseCase>();
        services.AddScoped<CreateQuestaoUseCase>();

        return services;
    }
}
