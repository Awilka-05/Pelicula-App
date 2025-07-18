using System;
using Microsoft.EntityFrameworkCore;
using PeliculaApp.Application.Services;
using PeliculaApp.Domain.Entities.Repositories;
using PeliculaApp.Domain.Validaciones;
using PeliculaApp.Infrastructure.Context;
using PeliculaApp.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PeliculaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppConnection")));


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

builder.Services.AddScoped<IPeliculaRepository, PeliculaRepository>();
builder.Services.AddScoped<IPeliculaService, PeliculaService>();
builder.Services.AddScoped<IValidarPelicula, ValidadorPelicula>();


var app = builder.Build();
app.UseCors("AllowAll");

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

