using MarkingVerifyAPI.Controllers;
using MarkingVerifyAPI.Infrastructure;
using MarkingVerifyAPI.Infrastructure.Repositories;
using MarkingVerifyAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationContext>(options => { options.UseNpgsql("Host=45.8.96.144;Database=VerifyProductionDB;Username=alco324;Password=}i=%Z#mHJlG5X$"); });

builder.Services.AddScoped<AlcoholLabelRepository>();
builder.Services.AddScoped<CigaretteLabelRepository>();
builder.Services.AddScoped<MilkLabelRepository>();

builder.Services.AddScoped<AlcoholLabelService>();
builder.Services.AddScoped<CigaretteLabelService>();
builder.Services.AddScoped<MilkLabelService>();

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
