using AdministracionHotelesLocales.Infra.Contexts;
using AdministracionHotelesLocales.Infra.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistence(config).AddDomainServices();

builder.Services.AddMediatR(Assembly.Load("AdministracionHotelesLocales.App"), typeof(Program).Assembly);
builder.Services.AddAutoMapper(Assembly.Load("AdministracionHotelesLocales.App"));
builder.Services.AddDbContext<AdministracionHotelesLocalesContext>(options =>
{
    options.UseSqlServer(config.GetConnectionString("AdministracionHotelesLocalesDb"), sqlOptions =>
    {
        sqlOptions.MigrationsHistoryTable("_MigrationHistory", config.GetValue<string>("SchemaName"));
    });
});


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
