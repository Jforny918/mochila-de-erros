using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MochilaDeErros.Infrastructure.Persistence;
using MochilaDeErros.Application.Interfaces.Repositories.Read;
using MochilaDeErros.Infrastructure.Repositories.Read;
using MochilaDeErros.Application.Interfaces.Repositories.Write;
using MochilaDeErros.Infrastructure.Repositories.Write;
using MochilaDeErros.Application.UseCases.Mochilas;

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
        services.AddScoped<GetMochilaCardsByUserIdUseCase>();
        services.AddScoped<CreateMochilaUseCase>();

        return services;
    }
}
