using API_Vadras;
using API_Vadras.Repository.PorudzbinaRepo;
using API_Vadras.Repository.ProizvodRepo;
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
