using Domain.Interfaces.IServices;
using Application.Service.Services;
using Microsoft.AspNetCore.Http;
using Domain.Interfaces.IRepositories;
using Infra.Data.Repository.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Context SQL Server
builder.Services.AddDbContext<SQLServerContext>
    (options => options.UseSqlServer("Server=LAPTOP-EBG33A6E\\SQLEXPRESS;Database=SistemaHospitalar;User Id=sa;Password=gibi2016;TrustServerCertificate=True;Encrypt=False;"));

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
