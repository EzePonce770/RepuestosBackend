using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Repository;
using Repository.Interfaces;
using Repository.Utils;
using Service;
using Service.Interfaces;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IFacturasRepository, FacturaRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IMarcasRepository, MarcasRepository>();
builder.Services.AddScoped<IRepuestoRepository,RepuestoRepository>();

builder.Services.AddScoped<IRepuestosService, RepuestosService>();
builder.Services.AddScoped<IMarcasService, MarcasService>();
builder.Services.AddScoped<IFacturasService, FacturasService>();
builder.Services.AddScoped<IClienteService, ClientesService>();


var connectionString = builder.Configuration.GetConnectionString("DB");

builder.Services.AddDbContext<repuestosContext>(options => {
    //options.UseMySql(connectionString);
    var serverVersion = Microsoft.EntityFrameworkCore.ServerVersion.Parse("9.0.1-mysql");
    options.UseMySql(connectionString, serverVersion);
});

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutoMapperProfiles());
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Policy",
        policy =>
        {
            policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api control venta repuesto", Version = "v1", Description = "Es una api con el objetivo de controlar la facturacion de repuestos de automotor" });

});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("Policy");

app.UseAuthorization();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.MapControllers();

app.Run();
