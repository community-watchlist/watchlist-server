using Api.Modules;
using Infrastructure;
using Infrastructure.Persistence;
using Scalar.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

var app = builder.Build();

builder.Services.AddOpenApi();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

await app.InitialiseDatabaseAsync();

app.UseCors();
app.MapControllers();

app.Run();
