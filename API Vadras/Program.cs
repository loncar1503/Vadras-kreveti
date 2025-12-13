using API_Vadras;
using API_Vadras.Middleware;
using API_Vadras.Repository.ApiKeyRepo;
using API_Vadras.Repository.PorudzbinaRepo;
using API_Vadras.Repository.ProizvodRepo;
using API_Vadras.Repository.RadniciRepo;
using API_Vadras.Repository.StavkaPorudzbineRepo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<VadrasDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("VadrasDb")));
builder.Services.AddScoped<IProizvod,ProizvodEF>();
builder.Services.AddScoped<IStavkaPorudzbine,StavkaPorudzbineEF>();
builder.Services.AddScoped<IPorudzbina,PorudzbinaEF>();
builder.Services.AddScoped<IApiKey, ApiKeyEF>();
builder.Services.AddScoped<IRadnici,RadniciEF>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
//app.UseMiddleware<ApiKeyMiddleware>();
app.MapControllers();

app.Run();
