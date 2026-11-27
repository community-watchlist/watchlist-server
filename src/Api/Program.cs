using Api.Modules;
using Application;
using Infrastructure;
using Infrastructure.Persistence;
using Scalar.AspNetCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.SetupServices();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();
// builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

await app.InitialiseDatabaseAsync();

app.UseCors();
app.MapControllers();

app.Run();
