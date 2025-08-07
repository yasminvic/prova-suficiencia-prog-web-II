using Application.Service.Services;
using Domain.Interfaces.IRepositories;
using Domain.Interfaces.IServices;
using Infra.Data.Repository.Data;
using Infra.Data.Repository.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

const string SECRET_KEY = "9fbbdd98-f2f4-4673-b48e-083ec1be44dc";

var builder = WebApplication.CreateBuilder(args);

// Context SQL Server
builder.Services.AddDbContext<DataContext>
    (options => options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Api;User Id=sa;Password=12345678;TrustServerCertificate=True;Encrypt=False;"));

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Config Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Buscar CEP" });

    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Autenticação TokenJWT",
        Description = "Entre com seu TokenJWT para acessar a API",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securityScheme);
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { securityScheme, new string[] {} }
    });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Service
builder.Services.AddScoped<IComandaService, ComandaService>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

//Repository
builder.Services.AddScoped<IComandaRepository, ComandaRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

//Sessao
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ISessao, Sessao>();

builder.Services.AddSession(o =>
{
    o.Cookie.HttpOnly = true;
    o.Cookie.IsEssential = true;
});


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
