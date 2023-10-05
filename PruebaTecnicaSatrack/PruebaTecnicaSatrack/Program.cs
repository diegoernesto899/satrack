using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PruebaTecnicaSatrack.Datos.Implementacion;
using PruebaTecnicaSatrack.Datos.Interfaces;
using PruebaTecnicaSatrack.Datos.Models;
using PruebaTecnicaSatrack.Negocio.Implementacion;
using PruebaTecnicaSatrack.Negocio.Interfaces;
using PruebaTecnicaSatrack.Transversal.Utilidades;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<SatrackContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStringSatrack"));
});

builder.Services.AddScoped<ITareasDatos, TareasDatos>();
builder.Services.AddScoped<ITareasNegocio, TareasNegocio>();

builder.Services.AddScoped<ICategoriaNegocio, CategoriaNegocio>();
builder.Services.AddScoped<ICategoriaDatos, CategoriaDatos>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddSwaggerGen();


builder.Services.AddCors(
    options=>options.AddPolicy("NuevaPolitica",app => 
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()
        )    
    );


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
