using CalculoDeSeguroDeVeiculos;
using CalculoDeSeguroDeVeiculos.Data;
using CalculoDeSeguroDeVeiculos.Repository.Interfaces;
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

app.UseAuthorization();

app.MapControllers();

app.Run();
