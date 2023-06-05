using PlatformService.Data;
using Microsoft.EntityFrameworkCore;
using PlatformService.SyncDatServices.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// When IPlatformRepo is requested, PlatformRepo is returned
builder.Services.AddScoped<IPlatformRepo, PlatformRepo>();
builder.Services.AddScoped<AppDbContext>();
// Requried for setting up dependency injection
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddHttpClient<ICommandDataClient, HttpCommandDataClient>();

Console.WriteLine($"Command Service Endpoint {builder.Configuration["CommandService"]}");
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

// Method for setting up data and migrations
PrepDb.PrepPopulation(app);

app.Run();
