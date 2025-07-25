using FighterTrainer.Application.Interfaces;
using FighterTrainer.Application.Services;
using FighterTrainer.Domain.Entities;
using FighterTrainer.Domain.Interfaces;
using FighterTrainer.Infrastructure.Context;
using FighterTrainer.Infrastructure.Repositories;
using FighterTrainer.Infrastructure.Services;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IUsuarioModalidadeRepository, UsuarioModalidadeRepository>();
builder.Services.AddScoped<IUsuarioModalidadeService, UsuarioModalidadeService>();
builder.Services.AddScoped<IModalidadeRepository, ModalidadeRepository>();
builder.Services.AddScoped<IModalidadeService, ModalidadeService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<IGraduacaoRepository, GraduacaoRepository>();
builder.Services.AddScoped<IGraduacaoService, GraduacaoService>();
builder.Services.AddScoped<GraduacaoService>();
builder.Services.AddScoped<IFederacaoRepository, FederacaoRepository>();
builder.Services.AddScoped<IFederacaoService, FederacaoService>();
builder.Services.AddScoped<FederacaoService>();
builder.Services.AddScoped<ICidadeRepository, CidadeRepository>();
builder.Services.AddScoped<ICidadeService, CidadeService>();
builder.Services.AddScoped<CidadeService>();
builder.Services.AddScoped<IUnidadeRepository, UnidadeRepository>();
builder.Services.AddScoped<IUnidadeService, UnidadeService>();
builder.Services.AddScoped<UnidadeService>();







builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
