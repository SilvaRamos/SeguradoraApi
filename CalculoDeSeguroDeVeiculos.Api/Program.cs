using CalculoDeSeguroDeVeiculos;
using CalculoDeSeguroDeVeiculos.Aplicacao.Interfaces;
using CalculoDeSeguroDeVeiculos.Aplicacao.Services;
using CalculoDeSeguroDeVeiculos.Dominio.Interfaces;
using CalculoDeSeguroDeVeiculos.Infra.Data.Context;
using CalculoDeSeguroDeVeiculos.Repository.Repositorios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("StringConexaoDev"));
});

builder.Services.AddScoped<ISeguroRepository,SeguroRepository>();
builder.Services.AddScoped<ISeguroService, SeguroServico>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseDefaultFiles();

app.UseStaticFiles();

app.UseEndpoints(endpoints =>
{
    endpoints.MapFallbackToController("index", "FallBack");
});

app.MapControllers();

app.Run();
