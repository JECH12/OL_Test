using OL_TEST.Models;
using Services.DTOs;
using Services.Interfaces;
using Services.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrar servicios
builder.Services.AddScoped<IFileCSVReader<ClientDTO>, ClientCSVReader>();
builder.Services.AddScoped<IFileCSVReader<ProductDTO>, ProductCSVReader>();
builder.Services.AddScoped<ILoadCSV, LoadCSV>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
