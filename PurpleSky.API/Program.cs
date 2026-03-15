using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PurpleSkyTTRPG.Application.Services;
using PurpleSkyTTRPG.Core.Interfaces;
using PurpleSkyTTRPG.DataAccess.Postgres;
using PurpleSkyTTRPG.DataAccess.Postgres.Repositories;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters
            .Add(new JsonStringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "PurpleSkyAPI", Version = "v1" });
});

builder.Services.AddDbContext<TTRPGDbContext>(
    options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(TTRPGDbContext)));
    });

builder.Services.AddScoped<ICharactersService, CharactersService>();
builder.Services.AddScoped<ICharactersRepository, CharactersRepository>();
 
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
