using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Receitas.Aplicacao.Comandos;
using Receitas.Aplicacao.Consultas;
using Receitas.Repositorio.Comandos;
using Receitas.Repositorio.Consultas;
using Supabase;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // Cria um SwaggerDoc para o grupo "Receitas"
    c.SwaggerDoc("Receitas", new OpenApiInfo
    {
        Title = "API Receitas",
        Version = "v1",
        Description = "API para gerenciar receitas"
    });

});

builder.Services.AddScoped<IReceitasConsultas, ReceitasConsultas>();
builder.Services.AddScoped<IReceitasConsultaRepositorio, ReceitasConsultaRepositorio>();

builder.Services.AddScoped<IReceitasComandos, ReceitasComandos>();
builder.Services.AddScoped<IReceitasComandosRepositorio, ReceitasComandosRepositorio>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options =>
    {
        options.SerializeAsV2 = true;
        options.RouteTemplate = "openapi/{documentName}.json";
    });
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/openapi/Receitas.json", "API Receitas v1");
    });
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => "API Online");

app.Run();
