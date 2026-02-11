using MochilaDeErros.Application.UseCases.Mochilas;
using MochilaDeErros.Infrastructure.DependencyInjection;
using MochilaDeErros.Application.UseCases.Questoes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure("Data Source=mochila.db");
builder.Services.AddScoped<CreateMochilaUseCase>();
builder.Services.AddScoped<GetMochilasUseCase>();
builder.Services.AddScoped<GetMochilaByIdUseCase>();

builder.Services.AddScoped<CreateQuestaoUseCase>();
builder.Services.AddScoped<GetQuestoesByMochilaUseCase>();
builder.Services.AddScoped<GetQuestaoByIdUseCase>();
builder.Services.AddScoped<UpdateQuestaoUseCase>();
builder.Services.AddScoped<ResponderQuestaoUseCase>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
