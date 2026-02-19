using MochilaDeErros.Application.UseCases.Mochilas;
using MochilaDeErros.Infrastructure.DependencyInjection;
using MochilaDeErros.Application.Interfaces.Repositories.Write;
using MochilaDeErros.Infrastructure.Repositories;
using MochilaDeErros.Application.UseCases.Usuarios;
using MochilaDeErros.Application.DTOs.Mochilas;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<GetMochilasByUserIdUseCase>();
builder.Services.AddScoped<GetMochilaCardsByUserIdUseCase>();
builder.Services.AddScoped<CreateQuestaoUseCase>();
builder.Services.AddScoped<IUsuarioReadRepository, UsuarioReadRepository>();
builder.Services.AddScoped<GetPlanoUsuarioUseCase>();
builder.Services.AddScoped<IUsuarioWriteRepository, UsuarioWriteRepository>();
builder.Services.AddScoped<CreateUsuarioUseCase>();
builder.Services.AddScoped<CreateMochilaRequest>();


builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("Front",
        p => p
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod()
    );
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.UseCors("Front");
app.Run();