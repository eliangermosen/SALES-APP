using Microsoft.EntityFrameworkCore;
using Sales.AppServices.Contract;
using Sales.AppServices.Service;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Dao;
using Sales.Infraestructure.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SalesContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddScoped<IUsuarioDb, UsuarioDb>();
builder.Services.AddScoped<IProductoDb, ProductoDb>();
builder.Services.AddScoped<IVentaDb, VentaDb>();
builder.Services.AddScoped<INegocioDb, NegocioDb>();
builder.Services.AddScoped<IDetalleVentaDb, DetalleVentaDb>();
builder.Services.AddScoped<IVentaService, VentaService>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<INegocioService, NegocioService>();
builder.Services.AddScoped<IDetalleVentaService, DetalleVentaService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
